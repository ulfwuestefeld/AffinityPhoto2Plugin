namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoomPixelSize : PluginDynamicCommand
    {
        public ViewZoomPixelSize() : base(displayName: "Zoom Pixel Size", description: "Zooms to pixel size.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key9, ModifierKey.Control);
        }
    }
}
