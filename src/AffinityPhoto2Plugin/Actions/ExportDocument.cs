namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ExportDocument : PluginDynamicCommand
    {
        public ExportDocument() : base(displayName: "Export", description: "Exports the document.", groupName: "File")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyS, ModifierKey.Control | ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
