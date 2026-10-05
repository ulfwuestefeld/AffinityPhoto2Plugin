namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class NewDocument : PluginDynamicCommand
    {
        public NewDocument() : base(displayName: "New Document", description: "Creates a new document.", groupName: "File")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyN, ModifierKey.Control);
        }
    }
}
