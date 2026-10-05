namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditCopyMerged : PluginDynamicCommand
    {
        public EditCopyMerged() : base(displayName: "Copy Merged", description: "Copies a merged copy to the clipboard.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyC, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
