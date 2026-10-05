namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewShowGrid : PluginDynamicCommand
    {
        public ViewShowGrid() : base(displayName: "Toggle Grid", description: "Shows or hides grid.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem7, ModifierKey.Control);
        }
    }
}
