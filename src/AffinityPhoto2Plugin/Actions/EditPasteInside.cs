namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditPasteInside : PluginDynamicCommand
    {
        public EditPasteInside() : base(displayName: "Paste Inside", description: "Pastes inside the selection.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyV, ModifierKey.Control | ModifierKey.Alt);
        }
    }
}
