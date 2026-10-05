namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerSelectAll : PluginDynamicCommand
    {
        public LayerSelectAll() : base(displayName: "Select All Layers", description: "Selects all layers.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyA, ModifierKey.Control | ModifierKey.Alt);
        }
    }
}
