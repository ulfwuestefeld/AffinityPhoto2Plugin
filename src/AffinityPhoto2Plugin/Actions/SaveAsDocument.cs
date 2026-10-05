namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SaveAsDocument : PluginDynamicCommand
    {
        public SaveAsDocument() : base(displayName: "Save As", description: "Saves the document with a new name.", groupName: "File")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyS, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
