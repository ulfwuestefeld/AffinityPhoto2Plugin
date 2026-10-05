namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditFillForeground : PluginDynamicCommand
    {
        public EditFillForeground() : base(displayName: "Fill with Foreground Color", description: "Fills the selection with the foreground color.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Back, ModifierKey.Alt);
        }
    }
}
