namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditUndo : PluginDynamicCommand
    {
        public EditUndo() : base(displayName: "Undo", description: "Undoes the last action.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyZ, ModifierKey.Control);
        }
    }
}
