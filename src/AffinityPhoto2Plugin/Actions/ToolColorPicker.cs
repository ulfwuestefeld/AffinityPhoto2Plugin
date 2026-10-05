namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class ToolColorPicker : PluginDynamicCommand
    {
        public ToolColorPicker() : base(displayName: "Color Picker", description: "Selects the color picker tool.", groupName: "Tools")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyI);
        }
    }
}
