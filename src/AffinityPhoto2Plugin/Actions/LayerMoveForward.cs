namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerMoveForward : PluginDynamicCommand
    {
        public LayerMoveForward() : base(displayName: "Move Forward", description: "Moves the layer forward in stacking order.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem6, ModifierKey.Control);
        }
    }
}
