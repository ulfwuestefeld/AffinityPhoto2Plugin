namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolFillGradient : PluginDynamicCommand
    {
        public ToolFillGradient() : base(displayName: "Toggle Fill/Gradient", description: "Toggles between fill and gradient tools.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyG);
        }
    }
}
