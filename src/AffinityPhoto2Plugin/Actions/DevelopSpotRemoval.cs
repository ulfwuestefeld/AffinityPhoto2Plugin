namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class DevelopSpotRemoval : PluginDynamicCommand
    {
        public DevelopSpotRemoval() : base(displayName: "Spot Removal", description: "Selects the Spot Removal tool in the Develop Persona.", groupName: "Develop Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyL);
        }
    }
}
