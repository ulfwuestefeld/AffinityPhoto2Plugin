namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewShowGuides : PluginDynamicCommand
    {
        public ViewShowGuides() : base(displayName: "Toggle Guides", description: "Shows or hides guides.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem1, ModifierKey.Control);
        }
    }
}
