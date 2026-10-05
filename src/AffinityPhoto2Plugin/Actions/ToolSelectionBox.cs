namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolSelectionBox : PluginDynamicCommand
    {
        public ToolSelectionBox() : base(displayName: "Toggle Selection Tools", description: "Toggles between selection box tools.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyM);
        }
    }
}
