namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerMoveToFront : PluginDynamicCommand
    {
        public LayerMoveToFront() : base(displayName: "Move to Front", description: "Moves the layer to the front.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem6, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
