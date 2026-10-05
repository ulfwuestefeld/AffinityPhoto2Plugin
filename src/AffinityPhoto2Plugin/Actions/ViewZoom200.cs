namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoom200 : PluginDynamicCommand
    {
        public ViewZoom200() : base(displayName: "Zoom 200%", description: "Sets zoom to 200%.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key2, ModifierKey.Control);
        }
    }
}
