namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolDodgeBurnSponge : PluginDynamicCommand
    {
        public ToolDodgeBurnSponge() : base(displayName: "Toggle Dodge/Burn/Sponge", description: "Toggles between dodge, burn, and sponge tools.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyO);
        }
    }
}
