namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditCut : PluginDynamicCommand
    {
        public EditCut() : base(displayName: "Cut", description: "Cuts the current selection.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyX, ModifierKey.Control);
        }
    }
}
