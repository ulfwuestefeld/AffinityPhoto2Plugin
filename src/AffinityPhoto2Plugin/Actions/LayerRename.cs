namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerRename : PluginDynamicCommand
    {
        public LayerRename() : base(displayName: "Rename Layer", description: "Renames the active layer.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyR, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
