namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ColorResetDefault : PluginDynamicCommand
    {
        public ColorResetDefault() : base(displayName: "Reset Colors", description: "Resets colors to default (black and white).", groupName: "Colors")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyD);
        }
    }
}
