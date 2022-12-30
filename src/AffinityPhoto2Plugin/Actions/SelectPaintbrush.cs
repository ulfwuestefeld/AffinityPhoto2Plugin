namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;

    public class SelectPaintbrush : PluginDynamicCommand
    {
        private Boolean _toggleState = false;

        private readonly String _image0ResourcePath;
        private readonly String _image1ResourcePath;

        public SelectPaintbrush() : base(displayName: "Paintbrush", description: "Selects the paint brush.", groupName: "Brushes")
        {
            this._image0ResourcePath = EmbeddedResources.FindFile("SelectPaintbrush0.png");
            this._image1ResourcePath = EmbeddedResources.FindFile("SelectPaintbrush1.png");
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            return !this._toggleState
                ? EmbeddedResources.ReadImage(this._image0ResourcePath)
                : EmbeddedResources.ReadImage(this._image1ResourcePath);
        }
        protected override void RunCommand(String actionParameter)
        {
            
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyB);
            this._toggleState = !this._toggleState;
            this.ActionImageChanged();
        }
    }
}
