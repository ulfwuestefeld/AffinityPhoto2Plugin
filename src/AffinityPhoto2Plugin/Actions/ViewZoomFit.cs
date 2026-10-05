namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewZoomFit : PluginDynamicCommand
    {
        public ViewZoomFit() : base(displayName: "Zoom Fit All", description: "Fits the entire document in the view.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key0, ModifierKey.Control);
        }
    }
}
