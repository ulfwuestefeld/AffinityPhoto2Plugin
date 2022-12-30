namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using System.Runtime.CompilerServices;

    public class SelectSelectionTool : PluginDynamicCommand
    {
        private Boolean _toggleState = false;
        private Boolean _paintingpixelselections = true;
        Int32 _togglecount = 0;

        private readonly String _image0ResourcePath;
        private readonly String _image1ResourcePath;
        private readonly String _image2ResourcePath;
        private readonly String _image3ResourcePath;

        public SelectSelectionTool() : base(displayName: "Selection Tools", description: "Toogles between painting pixel selection tool and flooding pixel selection tool.", groupName: "Tools Panel")
        {
            this._image0ResourcePath = EmbeddedResources.FindFile("SelectSelectionTool0.png");
            this._image1ResourcePath = EmbeddedResources.FindFile("SelectSelectionTool1.png");
            this._image2ResourcePath = EmbeddedResources.FindFile("SelectSelectionTool2.png");
            this._image3ResourcePath = EmbeddedResources.FindFile("SelectSelectionTool3.png");
        }
        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize)
        {
            if (!this._toggleState && this._paintingpixelselections)
            {
                return EmbeddedResources.ReadImage(this._image0ResourcePath);
            }
            else
            {
                if (this._toggleState && this._paintingpixelselections)
                {
                    return EmbeddedResources.ReadImage(this._image1ResourcePath);
                }
                else
                {
                    if (!this._toggleState && !this._paintingpixelselections)
                    {
                        return EmbeddedResources.ReadImage(this._image2ResourcePath);
                    }
                    else
                    {
                        if (this._toggleState && !this._paintingpixelselections)
                        {
                            return EmbeddedResources.ReadImage(this._image3ResourcePath);
                        }
                        else
                        {
                            return EmbeddedResources.ReadImage(this._image0ResourcePath);
                        }
                    }
                }
            }
        }
        protected override void RunCommand(String actionParameter)
        {
            this.Plugin.ClientApplication.SendKeyboardShortcut(VirtualKeyCode.KeyW);
            this._toggleState = !this._toggleState;
            if()
            _togglecount++;
            this.ActionImageChanged();
        }
    }
}
