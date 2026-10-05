namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoom400 : PluginDynamicCommand
    {
        public ViewZoom400() : base(displayName: "Zoom 400%", description: "Sets zoom to 400%.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key3, ModifierKey.Control);
        }
    }
}
