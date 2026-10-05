namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditRestore : PluginDynamicCommand
    {
        public EditRestore() : base(displayName: "Restore", description: "Restores the last state.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Back, ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
