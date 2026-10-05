namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerNew : PluginDynamicCommand
    {
        public LayerNew() : base(displayName: "New Layer", description: "Creates a new layer.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyN, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
