namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolFreehandSelection : PluginDynamicCommand
    {
        public ToolFreehandSelection() : base(displayName: "Freehand Selection", description: "Selects the freehand selection tool.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyL);
        }
    }
}
