namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using System.Runtime.CompilerServices;

    public class AdjustBrushSize : PluginDynamicAdjustment
    {
        private Int32 _counter = 0;

        private Boolean _toggleState = false;

        private readonly String _image0ResourcePath;
        private readonly String _image1ResourcePath;

        public AdjustBrushSize() : base(displayName: "Brush size", description: "Dial changes the size of the brush.", groupName: "Tools Panel", hasReset: false)
        {
            this._image0ResourcePath = EmbeddedResources.FindFile("AdjustBrushSize0.png");
            this._image1ResourcePath = EmbeddedResources.FindFile("AdjustBrushSize1.png");
        }

        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            this._counter += diff;
            if (diff < 0)
            {
                for (Int32 i = 0; i > diff; i--)
                {
                    // ToDo 
                    //this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key9, ModifierKey.Alt, ModifierKey.Control);
                }
            }
            if (diff > 0)
            {
                for (Int32 i = 0; i < diff; i++)
                {
                    // ToDo
                    //this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key8, ModifierKey.Alt, ModifierKey.Control);
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

        // Returns the adjustment value that is shown next to the dial.
        protected override String GetAdjustmentValue(String actionParameter) => this._counter.ToString();
    }
}
