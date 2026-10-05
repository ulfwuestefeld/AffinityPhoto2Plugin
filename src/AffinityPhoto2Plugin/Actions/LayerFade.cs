namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerFade : PluginDynamicCommand
    {
        public LayerFade() : base(displayName: "Fade Layer", description: "Fades the layer opacity.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyF, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
