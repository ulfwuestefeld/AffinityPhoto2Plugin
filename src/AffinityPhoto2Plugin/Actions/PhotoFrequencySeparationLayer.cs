namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class PhotoFrequencySeparationLayer : PluginDynamicCommand
    {
        public PhotoFrequencySeparationLayer() : base(displayName: "Frequency Separation Layer", description: "Switches the active layer in a frequency separation setup.", groupName: "Photo Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyF);
        }
    }
}
