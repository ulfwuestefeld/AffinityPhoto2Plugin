namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolShapes : PluginDynamicCommand
    {
        public ToolShapes() : base(displayName: "Toggle Shape Tools", description: "Toggles between rectangle, ellipse, and rounded rectangle tools.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyU);
        }
    }
}
