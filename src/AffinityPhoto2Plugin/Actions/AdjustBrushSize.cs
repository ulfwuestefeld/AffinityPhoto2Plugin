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

        public AdjustBrushSize() : base(displayName: "Brush size", description: "Dial changes the size of the brush, click resets it to the initial value.", groupName: "Tools Panel", hasReset: true)
        {
            this._image0ResourcePath = EmbeddedResources.FindFile("AdjustBrushSize0.png");
            this._image1ResourcePath = EmbeddedResources.FindFile("AdjustBrushSize1.png");
        }

        protected override void ApplyAdjustment(String actionParameter, Int32 diff)
        {
            this._counter += diff;
            if (diff < 0)
            {
                for (var i = 0; i > diff; i--)
                {
                    // ToDo 
                    //this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key9, ModifierKey.Alt | ModifierKey.Control);
                    this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem6);
                }
            }
            if (diff > 0)
            {
                for (var i = 0; i < diff; i++)
                {
                    // ToDo
                    //this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key8, ModifierKey.Alt, ModifierKey.Control);
                    //this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Key8, ModifierKey.Alt | ModifierKey.Control);
                    this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem4);
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
            if (this._counter < 0)
            {
                for (var i = 0; i >= this._counter; i--)
                {
                    this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem4);
                }
            }
            if (this._counter > 0)
            {
                for (var i = 0; i <= this._counter; i++)
                {
                    this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.Oem6);
                }
            }
            this._counter = 0;
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
