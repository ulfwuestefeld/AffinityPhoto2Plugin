namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoomActualSize : PluginDynamicCommand
    {
        public ViewZoomActualSize() : base(displayName: "Zoom Actual Size", description: "Zooms to actual pixel size.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key8, ModifierKey.Control);
        }
    }
}
