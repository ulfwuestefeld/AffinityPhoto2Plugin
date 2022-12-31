namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;

    public class SelectCloneTool : PluginDynamicCommand
    {
        //private Boolean _toggleState = false;

        private readonly String _image0ResourcePath;
        //private readonly String _image1ResourcePath;

        public SelectCloneTool() : base(displayName: "Clone tool", description: "Selects the clone tool.", groupName: "Tools Panel")
        {
            this._image0ResourcePath = EmbeddedResources.FindFile("SelectCloneTool0.png");
            //this._image1ResourcePath = EmbeddedResources.FindFile("SelectCloneTool1.png");
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            /*return !this._toggleState
                ? EmbeddedResources.ReadImage(this._image0ResourcePath)
                : EmbeddedResources.ReadImage(this._image1ResourcePath);*/
            return EmbeddedResources.ReadImage(this._image0ResourcePath);
        }
        protected override void RunCommand(String actionParameter)
        {
            /*if (!this._toggleState)
            {
                this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyH);
            }
            else
            {
                this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyI);
            }
            this._toggleState = !this._toggleState;*/
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyK);
            //this.ActionImageChanged();
        }
    }
}
