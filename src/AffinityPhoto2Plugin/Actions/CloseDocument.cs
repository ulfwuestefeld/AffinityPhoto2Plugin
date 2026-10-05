namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class CloseDocument : PluginDynamicCommand
    {
        public CloseDocument() : base(displayName: "Close Document", description: "Closes the active document.", groupName: "File")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyW, ModifierKey.Control);
        }
    }
}
