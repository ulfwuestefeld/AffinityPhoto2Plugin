namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerSelectParent : PluginDynamicCommand
    {
        public LayerSelectParent() : base(displayName: "Select Parent Layer", description: "Selects the parent layer.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.ArrowUp, ModifierKey.Control);
        }
    }
}
