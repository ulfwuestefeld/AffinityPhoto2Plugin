namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerMoveBackward : PluginDynamicCommand
    {
        public LayerMoveBackward() : base(displayName: "Move Backward", description: "Moves the layer backward in stacking order.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem4, ModifierKey.Control);
        }
    }
}
