namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectAll : PluginDynamicCommand
    {
        public SelectAll() : base(displayName: "Select All", description: "Selects all.", groupName: "Selection")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyA, ModifierKey.Control);
        }
    }
}
