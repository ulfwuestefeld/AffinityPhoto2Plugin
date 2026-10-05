namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectGrowShrink : PluginDynamicCommand
    {
        public SelectGrowShrink() : base(displayName: "Grow/Shrink Selection", description: "Grows or shrinks the selection.", groupName: "Selection")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyB, ModifierKey.Control);
        }
    }
}
