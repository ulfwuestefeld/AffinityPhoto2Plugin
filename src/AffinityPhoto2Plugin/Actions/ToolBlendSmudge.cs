namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolBlendSmudge : PluginDynamicCommand
    {
        public ToolBlendSmudge() : base(displayName: "Smudge Brush", description: "Selects the smudge/blend brush tool.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyS);
        }
    }
}
