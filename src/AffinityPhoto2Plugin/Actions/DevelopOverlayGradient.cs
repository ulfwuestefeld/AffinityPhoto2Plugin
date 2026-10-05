namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class DevelopOverlayGradient : PluginDynamicCommand
    {
        public DevelopOverlayGradient() : base(displayName: "Overlay Gradient", description: "Selects the Overlay Gradient tool in the Develop Persona.", groupName: "Develop Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyG);
        }
    }
}
