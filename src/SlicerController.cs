using System.Reflection;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using SpriteSlicer.Data;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

namespace SpriteSlicer.src
{
    public class SlicerController
    {

        private SlicerData _data;

        public SlicerController(Desktop _desktop)
        {
            ScalablePanel _panel = (ScalablePanel)_desktop.Controls.Get("Panel");

            PropertyGrid _grid = (PropertyGrid)_panel.Controls.Get("Grid");
            _grid.OnPropertyValueChanged += ValueChanged;
            
            _data = new SlicerData();
            _grid.Select_Object(_data);

            Button _button = (Button)_panel.Controls.Get("SliceButton");
            _button.OnMouseDown += ButtonPress;
        }
        private void ValueChanged(object sender, PropertyInfo info)
        {
            //update the shape system
        }
        private void ButtonPress(MouseEventArgs e)
        {
            //call slicer
        }
    }
}


