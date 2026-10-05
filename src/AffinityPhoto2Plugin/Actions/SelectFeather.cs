namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectFeather : PluginDynamicCommand
    {
        public SelectFeather() : base(displayName: "Feather Selection", description: "Feathers the selection.", groupName: "Selection")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.F6, ModifierKey.Shift);
        }
    }
}
