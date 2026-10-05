namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoom100 : PluginDynamicCommand
    {
        public ViewZoom100() : base(displayName: "Zoom 100%", description: "Sets zoom to 100%.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key1, ModifierKey.Control);
        }
    }
}
