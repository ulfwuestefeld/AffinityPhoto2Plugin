namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditTransferStyle : PluginDynamicCommand
    {
        public EditTransferStyle() : base(displayName: "Transfer Style", description: "Transfers style from one object to another.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyV, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
