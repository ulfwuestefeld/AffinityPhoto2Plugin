namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LiquifyConcaveDistortion : PluginDynamicCommand
    {
        public LiquifyConcaveDistortion() : base(displayName: "Concave Distortion", description: "Selects the Concave Distortion tool in the Liquify Persona.", groupName: "Liquify Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyU);
        }
    }
}
