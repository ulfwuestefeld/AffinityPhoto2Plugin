namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolSelectionBrush : PluginDynamicCommand
    {
        public ToolSelectionBrush() : base(displayName: "Toggle Selection Brush", description: "Toggles between selection brush and area select tool.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyW);
        }
    }
}
