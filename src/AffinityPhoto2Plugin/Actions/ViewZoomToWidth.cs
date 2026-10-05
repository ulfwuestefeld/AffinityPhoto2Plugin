namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoomToWidth : PluginDynamicCommand
    {
        public ViewZoomToWidth() : base(displayName: "Zoom to Width", description: "Zooms to fit document width.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key0, ModifierKey.Alt | ModifierKey.Shift);
        }
    }
}
