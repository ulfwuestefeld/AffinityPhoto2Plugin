namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerGroup : PluginDynamicCommand
    {
        public LayerGroup() : base(displayName: "Group Layers", description: "Groups selected layers.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyG, ModifierKey.Control);
        }
    }
}
