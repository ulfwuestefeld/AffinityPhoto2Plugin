namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditRedo : PluginDynamicCommand
    {
        public EditRedo() : base(displayName: "Redo", description: "Redoes the last undone action.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyZ, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
