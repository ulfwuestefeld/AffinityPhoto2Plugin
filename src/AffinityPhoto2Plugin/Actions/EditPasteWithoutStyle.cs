namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditPasteWithoutStyle : PluginDynamicCommand
    {
        public EditPasteWithoutStyle() : base(displayName: "Paste Without Style", description: "Pastes without style attributes.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyV, ModifierKey.Control | ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
