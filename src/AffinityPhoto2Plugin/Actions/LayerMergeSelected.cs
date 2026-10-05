namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerMergeSelected : PluginDynamicCommand
    {
        public LayerMergeSelected() : base(displayName: "Merge Selected Layers", description: "Merges selected layers.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyE, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
