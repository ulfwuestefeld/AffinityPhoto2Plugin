namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditTransferEffect : PluginDynamicCommand
    {
        public EditTransferEffect() : base(displayName: "Transfer Effect", description: "Transfers effect from one object to another.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyV, ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
