namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerMoveToBack : PluginDynamicCommand
    {
        public LayerMoveToBack() : base(displayName: "Move to Back", description: "Moves the layer to the back.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem4, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
