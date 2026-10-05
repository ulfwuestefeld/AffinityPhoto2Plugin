namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectNone : PluginDynamicCommand
    {
        public SelectNone() : base(displayName: "Deselect All", description: "Deselects everything.", groupName: "Selection")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyD, ModifierKey.Control);
        }
    }
}
