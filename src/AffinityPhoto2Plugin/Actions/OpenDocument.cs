namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class OpenDocument : PluginDynamicCommand
    {
        public OpenDocument() : base(displayName: "Open Document", description: "Opens a document.", groupName: "File")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyO, ModifierKey.Control);
        }
    }
}
