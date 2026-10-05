namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolText : PluginDynamicCommand
    {
        public ToolText() : base(displayName: "Toggle Text Tools", description: "Toggles between text editing tools.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyT);
        }
    }
}
