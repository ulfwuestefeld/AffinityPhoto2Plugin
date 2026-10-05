namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class EditFillBackground : PluginDynamicCommand
    {
        public EditFillBackground() : base(displayName: "Fill with Background Color", description: "Fills the selection with the background color.", groupName: "Edit")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Back, ModifierKey.Control);
        }
    }
}
