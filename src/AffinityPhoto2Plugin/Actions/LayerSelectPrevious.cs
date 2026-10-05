namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerSelectPrevious : PluginDynamicCommand
    {
        public LayerSelectPrevious() : base(displayName: "Select Previous Layer", description: "Selects the previous layer.", groupName: "Layers")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem4, ModifierKey.Alt);
        }
    }
}
