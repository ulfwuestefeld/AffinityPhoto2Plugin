namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LiquifyConvexDistortion : PluginDynamicCommand
    {
        public LiquifyConvexDistortion() : base(displayName: "Convex Distortion", description: "Selects the Convex Distortion tool in the Liquify Persona.", groupName: "Liquify Persona")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyN);
        }
    }
}
