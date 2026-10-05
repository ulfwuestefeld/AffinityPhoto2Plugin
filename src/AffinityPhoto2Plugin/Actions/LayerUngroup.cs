namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerUngroup : PluginDynamicCommand
    {
        public LayerUngroup() : base(displayName: "Ungroup Layers", description: "Ungroups the selected group.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyG, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
