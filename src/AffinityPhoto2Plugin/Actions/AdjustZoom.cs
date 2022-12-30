namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using System.Runtime.CompilerServices;

    public class AdjustZoom : PluginDynamicAdjustment
    {
        private Int32 _counter = 0;

        private Boolean _toggleState = false;

        private readonly String _image0ResourcePath;
        private readonly String _image1ResourcePath;

        public AdjustZoom() : base(displayName: "Zoom", description: "Dial Zooms in or out, click resets zoom to fit.", groupName: "Tools Panel", hasReset: true)
        {
            this._image0ResourcePath = EmbeddedResources.FindFile("AdjustZoom0.png");
            this._image1ResourcePath = EmbeddedResources.FindFile("AdjustZoom1.png");
        }

        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            this._counter += diff;
            if (diff < 0)
            {
                for (Int32 i = 0; i > diff; i--)
                {
                    //this.Plugin.ClientApplication.
                    this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Minus, ModifierKey.Control);
                }
            }
            if (diff > 0)
            {
                for (Int32 i = 0; i < diff; i++)
                {
                    this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Add, ModifierKey.Control);
                }
            }
            this.AdjustmentValueChanged();
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return !this._toggleState
                ? EmbeddedResources.ReadImage(this._image0ResourcePath)
                : EmbeddedResources.ReadImage(this._image1ResourcePath);
        }

        protected override void RunCommand(String actionParameter)
        {
            this._counter = 0;
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key0,ModifierKey.Control);
            this._toggleState = !this._toggleState;
            this.ActionImageChanged();
            this.AdjustmentValueChanged();
            this._toggleState = !this._toggleState;
            this.ActionImageChanged();
        }

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter) => this._counter.ToString();
    }
}
