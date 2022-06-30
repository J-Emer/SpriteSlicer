using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

using SpriteSlicer.Data;

namespace SpriteSlicer
{
    public class MainDesktop : Desktop
    {
        public MainDesktop(GraphicsDevice _graphics, ContentManager _content, GameWindow _window, string _defaultStringName) : base(_graphics, _content, _window, _defaultStringName){}

        public override void Load()
        {
            ScalablePanel _panel = new ScalablePanel(this)
            {
                Name = "Panel",
                Size = new Vector2_Int(300, 400),
                DockStyle = DockStyle.Left,
                Layout = new Vertical_Stretch_Layout(),
                Padding = new Padding(15)
            };
            Controls.Add(_panel);

            PropertyGrid _grid = new PropertyGrid(this, this.DefaultFontName)
            {
                Name = "Grid",
                Size = new Vector2_Int(200,200)
            };
            _panel.Controls.Add(_grid);

            _grid.Select_Object(new SlicerData());

            Button _loadbutton = new Button(this)
            {
                Name = "LoadButton",
                Text = "Load Image"
            };
            _panel.Controls.Add(_loadbutton);


            Button _sliceButton = new Button(this)
            {
                Name = "SliceButton",
                Text = "Slice"
            };
            _panel.Controls.Add(_sliceButton);
        }
    }
}


