namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class DevelopWhiteBalance : PluginDynamicCommand
    {
        public DevelopWhiteBalance() : base(displayName: "White Balance", description: "Selects the White Balance tool in the Develop Persona.", groupName: "Develop Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyW);
        }
    }
}
