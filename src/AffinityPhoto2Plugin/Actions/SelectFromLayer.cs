namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectFromLayer : PluginDynamicCommand
    {
        public SelectFromLayer() : base(displayName: "Select from Layer", description: "Creates selection from layer content.", groupName: "Selection")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            // Ctrl+Click on layer thumbnail - this would be implemented via context menu or requires layer interaction
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyO, ModifierKey.Control | ModifierKey.Shift);
        }
    }
}
