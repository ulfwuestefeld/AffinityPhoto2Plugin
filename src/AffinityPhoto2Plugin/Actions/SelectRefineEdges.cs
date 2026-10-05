namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class SelectRefineEdges : PluginDynamicCommand
    {
        public SelectRefineEdges() : base(displayName: "Refine Selection Edges", description: "Refines the selection edges.", groupName: "Selection")
        {
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return null;
        }

        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyR, ModifierKey.Control | ModifierKey.Alt);
        }
    }
}
