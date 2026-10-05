namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoom800 : PluginDynamicCommand
    {
        public ViewZoom800() : base(displayName: "Zoom 800%", description: "Sets zoom to 800%.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key4, ModifierKey.Control);
        }
    }
}
