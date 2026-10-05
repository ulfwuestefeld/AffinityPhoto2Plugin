namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class DevelopRedEye : PluginDynamicCommand
    {
        public DevelopRedEye() : base(displayName: "Red Eye", description: "Selects the Red Eye tool in the Develop Persona.", groupName: "Develop Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyR);
        }
    }
}
