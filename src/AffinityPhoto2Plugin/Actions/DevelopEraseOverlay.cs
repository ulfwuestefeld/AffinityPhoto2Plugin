namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class DevelopEraseOverlay : PluginDynamicCommand
    {
        public DevelopEraseOverlay() : base(displayName: "Erase Overlay", description: "Selects the Erase Overlay tool in the Develop Persona.", groupName: "Develop Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyE);
        }
    }
}
