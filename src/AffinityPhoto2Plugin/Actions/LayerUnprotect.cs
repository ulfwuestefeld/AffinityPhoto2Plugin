namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerUnprotect : PluginDynamicCommand
    {
        public LayerUnprotect() : base(displayName: "Unprotect Layer", description: "Unprotects the layer.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyL, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
