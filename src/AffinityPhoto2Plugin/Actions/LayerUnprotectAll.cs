namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerUnprotectAll : PluginDynamicCommand
    {
        public LayerUnprotectAll() : base(displayName: "Unprotect All Layers", description: "Unprotects all layers.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyL, ModifierKey.Control | ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
