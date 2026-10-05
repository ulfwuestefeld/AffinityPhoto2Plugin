namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LiquifyMeshGrid : PluginDynamicCommand
    {
        public LiquifyMeshGrid() : base(displayName: "Mesh Grid", description: "Toggles the mesh grid in the Liquify Persona.", groupName: "Liquify Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyC);
        }
    }
}
