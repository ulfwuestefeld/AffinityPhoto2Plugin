namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerDuplicate : PluginDynamicCommand
    {
        public LayerDuplicate() : base(displayName: "Duplicate Layer", description: "Duplicates the active layer.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyJ, ModifierKey.Control);
        }
    }
}
