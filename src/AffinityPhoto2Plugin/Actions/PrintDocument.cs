namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class PrintDocument : PluginDynamicCommand
    {
        public PrintDocument() : base(displayName: "Print", description: "Prints the document.", groupName: "File")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyP, ModifierKey.Control);
        }
    }
}
