namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Helper class for loading embedded resources from the assembly.
    /// Resources are embedded in the assembly and accessed by their manifest resource name.
    /// </summary>
    public static class EmbeddedResources
    {
        private static readonly Assembly _assembly = typeof(EmbeddedResources).Assembly;
        private static readonly String _assemblyName = _assembly.GetName().Name;
        private static Dictionary<String, String> _resourceCache = new Dictionary<String, String>();
        private static Boolean _initialized = false;

        /// <summary>
        /// Initializes the resource cache (called once on first use).
        /// This maps short file names (e.g., "AdjustZoom0.png") to their full manifest resource names.
        /// </summary>
        private static void InitializeCache()
        {
            if (_initialized)
                return;

            _initialized = true;
            var resourceNames = _assembly.GetManifestResourceNames();

            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"📦 Assembly Resources ({_assemblyName}): {resourceNames.Length} resources found");
            foreach (var resourceName in resourceNames)
            {
                if (resourceName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    System.Diagnostics.Debug.WriteLine($"   📄 {resourceName}");
                }
            }
            #endif

            // Build a cache of short names to full resource names
            foreach (var resourceName in resourceNames)
            {
                // Extract the short file name (last part)
                var shortName = System.IO.Path.GetFileName(resourceName);
                _resourceCache[shortName.ToLowerInvariant()] = resourceName;
            }
        }

        /// <summary>
        /// Finds an embedded resource file by name.
        /// Returns the manifest resource name that can be used by the Loupedeck SDK.
        /// </summary>
        /// <param name="fileName">The file name to find (e.g., "AdjustZoom0.png")</param>
        /// <returns>The full manifest resource name, or null if not found</returns>
        public static String FindFile(String fileName)
        {
            if (String.IsNullOrWhiteSpace(fileName))
            {
                System.Diagnostics.Debug.WriteLine($"⚠️ FindFile called with null or empty fileName");
                return null;
            }

            InitializeCache();

            // Try exact match (case-insensitive)
            var lowerFileName = fileName.ToLowerInvariant();
            if (_resourceCache.TryGetValue(lowerFileName, out var resourceName))
            {
                #if DEBUG
                System.Diagnostics.Debug.WriteLine($"✅ Found resource: {fileName} → {resourceName}");
                #endif
                return resourceName;
            }

            // Fallback: try old-style search
            var resourceNames = _assembly.GetManifestResourceNames();
            foreach (var rn in resourceNames)
            {
                if (rn.EndsWith(fileName, StringComparison.OrdinalIgnoreCase))
                {
                    #if DEBUG
                    System.Diagnostics.Debug.WriteLine($"✅ Found resource (fallback): {fileName} → {rn}");
                    #endif
                    return rn;
                }
            }

            // Not found
            System.Diagnostics.Debug.WriteLine($"❌ Embedded resource not found: {fileName}");
            #if DEBUG
            System.Diagnostics.Debug.WriteLine($"   Available PNG resources:");
            foreach (var rn in resourceNames)
            {
                if (rn.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    System.Diagnostics.Debug.WriteLine($"   - {rn}");
                }
            }
            #endif

            return null;
        }

        /// <summary>
        /// Reads an embedded resource image and returns a BitmapImage.
        /// This returns null - the Loupedeck SDK will load images directly using the manifest resource name.
        /// </summary>
        /// <param name="resourcePath">The manifest resource name (from FindFile)</param>
        /// <returns>Always returns null; the SDK handles resource loading</returns>
        public static BitmapImage ReadImage(String resourcePath)
        {
            // Return null - let the Loupedeck SDK framework handle image loading from the manifest resource name
            return null;
        }
    }
}
