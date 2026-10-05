namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditPaste : PluginDynamicCommand
    {
        public EditPaste() : base(displayName: "Paste", description: "Pastes the clipboard contents.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyV, ModifierKey.Control);
        }
    }
}
