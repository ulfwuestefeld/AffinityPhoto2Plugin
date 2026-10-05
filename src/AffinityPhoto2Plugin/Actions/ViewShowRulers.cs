namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewShowRulers : PluginDynamicCommand
    {
        public ViewShowRulers() : base(displayName: "Toggle Rulers", description: "Shows or hides rulers.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyR, ModifierKey.Control);
        }
    }
}
