namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LiquifyClearMask : PluginDynamicCommand
    {
        public LiquifyClearMask() : base(displayName: "Clear Mask", description: "Clears the mask in the Liquify Persona.", groupName: "Liquify Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyD);
        }
    }
}
