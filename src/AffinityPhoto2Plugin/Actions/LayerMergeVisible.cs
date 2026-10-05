namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerMergeVisible : PluginDynamicCommand
    {
        public LayerMergeVisible() : base(displayName: "Merge Visible Layers", description: "Merges all visible layers.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyE, ModifierKey.Control | ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
