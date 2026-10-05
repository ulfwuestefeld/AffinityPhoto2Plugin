namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LiquifyInflate : PluginDynamicCommand
    {
        public LiquifyInflate() : base(displayName: "Inflate", description: "Selects the Inflate tool in the Liquify Persona.", groupName: "Liquify Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyW);
        }
    }
}
