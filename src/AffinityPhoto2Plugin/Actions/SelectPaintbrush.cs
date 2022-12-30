namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SelectPaintbrush : PluginDynamicCommand
    {
        public SelectPaintbrush() : base(displayName: "Paintbrush", description: "Selects the paint brush.", groupName: "Brushes")
        {
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyB);
        }
    }
}
