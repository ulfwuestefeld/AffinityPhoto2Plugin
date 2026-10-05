namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewResetRotation : PluginDynamicCommand
    {
        public ViewResetRotation() : base(displayName: "Reset Rotation", description: "Resets canvas rotation to default.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyR, ModifierKey.Control | ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
