namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerSelectNext : PluginDynamicCommand
    {
        public LayerSelectNext() : base(displayName: "Select Next Layer", description: "Selects the next layer.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem6, ModifierKey.Alt);
        }
    }
}
