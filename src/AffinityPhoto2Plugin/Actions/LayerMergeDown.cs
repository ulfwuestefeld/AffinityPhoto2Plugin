namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerMergeDown : PluginDynamicCommand
    {
        public LayerMergeDown() : base(displayName: "Merge Down", description: "Merges the layer down.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyE, ModifierKey.Control);
        }
    }
}
