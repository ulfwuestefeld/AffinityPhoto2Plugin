namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;

    public class SelectBlemishRemovalTool : PluginDynamicCommand
    {
        //private Boolean _toggleState = false;

        private readonly String _image0ResourcePath;
        //private readonly String _image1ResourcePath;

        public SelectBlemishRemovalTool() : base(displayName: "Blemish removal Tools", description: "Toggles through the blemish removal tools.", groupName: "Tools Panel")
        {
            this._image0ResourcePath = EmbeddedResources.FindFile("SelectBlemishRemovalTool0.png");
            //this._image1ResourcePath = EmbeddedResources.FindFile("SelectBlemishRemovalTool1.png");
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            //return !this._toggleState
            //    ? EmbeddedResources.ReadImage(this._image0ResourcePath)
            //    : EmbeddedResources.ReadImage(this._image1ResourcePath);
            return EmbeddedResources.ReadImage(this._image0ResourcePath);
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyJ);
            //this._toggleState = !this._toggleState;
            this.ActionImageChanged();
        }
    }
}
