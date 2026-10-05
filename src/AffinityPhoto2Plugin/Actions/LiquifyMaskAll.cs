namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LiquifyMaskAll : PluginDynamicCommand
    {
        public LiquifyMaskAll() : base(displayName: "Mask All", description: "Masks the entire image in the Liquify Persona.", groupName: "Liquify Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyA);
        }
    }
}
