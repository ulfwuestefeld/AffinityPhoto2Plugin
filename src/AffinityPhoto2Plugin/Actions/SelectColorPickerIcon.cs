namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectColorPickerIcon : PluginDynamicCommand
    {
        public SelectColorPickerIcon() : base(displayName: "Select Color Picker (Icon)", description: "Selects color picker tool.", groupName: "Tools")
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
