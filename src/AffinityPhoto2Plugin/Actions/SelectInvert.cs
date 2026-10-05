namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectInvert : PluginDynamicCommand
    {
        public SelectInvert() : base(displayName: "Invert Selection", description: "Inverts the current selection.", groupName: "Selection")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyI, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
