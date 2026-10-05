namespace Loupedeck.AffinityPhoto2Plugin
{
    using System;
    using Loupedeck;

    public class LayerOpacityPreset : PluginDynamicCommand
    {
        public LayerOpacityPreset() : base(displayName: "Layer Opacity Preset", description: "Sets the layer opacity to a keyboard shortcut preset.", groupName: "Photo Persona")
        {
            for (var percent = 10; percent <= 90; percent += 10)
            {
                this.AddParameter((percent / 10).ToString(), $"{percent}% Opacity", "Layer Opacity");
            }
            this.AddParameter("0", "100% Opacity", "Layer Opacity");
            this.ParametersChanged();
        }

        protected override BitmapImage GetCommandImage(String actionParameter, PluginImageSize imageSize) => null;

        protected override void RunCommand(String actionParameter)
        {
            var key = actionParameter switch
            {
                "0" => VirtualKeyCode.Key0,
                "1" => VirtualKeyCode.Key1,
                "2" => VirtualKeyCode.Key2,
                "3" => VirtualKeyCode.Key3,
                "4" => VirtualKeyCode.Key4,
                "5" => VirtualKeyCode.Key5,
                "6" => VirtualKeyCode.Key6,
                "7" => VirtualKeyCode.Key7,
                "8" => VirtualKeyCode.Key8,
                "9" => VirtualKeyCode.Key9,
                _ => throw new ArgumentException($"Unsupported layer-opacity preset: {actionParameter}", nameof(actionParameter))
            };
            this.Plugin.ClientApplication.SendKeyboardShortcut(key);
        }
    }
}
