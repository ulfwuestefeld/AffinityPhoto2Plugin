namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ViewToggleSplitView : PluginDynamicCommand
    {
        public ViewToggleSplitView() : base(displayName: "Toggle Split View", description: "Toggles split view mode.", groupName: "View")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem2);
        }
    }
}
