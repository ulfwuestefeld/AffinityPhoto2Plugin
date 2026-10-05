namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerShowAll : PluginDynamicCommand
    {
        public LayerShowAll() : base(displayName: "Show All Layers", description: "Shows all hidden layers.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyH, ModifierKey.Control | ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
