using System.Reflection;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpriteSlicer.Data;
using SpriteSlicer.Shapes;

using EditorUI_DX;
using EditorUI_DX.Controls;
using EditorUI_DX.Utils;

namespace SpriteSlicer.src
{
    public class SlicerController : DrawableGameComponent
    {
        private Texture2D _mainTexture;
        private SlicerData _data;

        public SlicerController(Desktop _desktop, Game _game) : base(_game)
        {
            _game.Components.Add(this);

            this.DrawOrder = 0;

            ScalablePanel _panel = (ScalablePanel)_desktop.Controls.Get("Panel");

            PropertyGrid _grid = (PropertyGrid)_panel.Controls.Get("Grid");
            _grid.OnPropertyValueChanged += ValueChanged;
            
            _data = new SlicerData();
            _grid.Select_Object(_data);


            Button _loadButton = (Button)_panel.Controls.Get("LoadButton");
            _loadButton.OnMouseDown += LoadImage;

            Button _sliceButton = (Button)_panel.Controls.Get("SliceButton");
            _sliceButton.OnMouseDown += ButtonPress;
        }
        private void ValueChanged(object sender, PropertyInfo info)
        {
            ShapeSystem.Instance.Clear();

            for (int x = 0; x < _data.Columbs; x++)
            {
                for (int y = 0; y < _data.Rows; y++)
                {
                    Vector2 _pos = new Vector2(x,y) * _data.CellSize;

                    ShapeSystem.Instance.AddRect(_pos, (_data.CellSize - Vector2.One), 1);
                }
            }
        }
        private void ButtonPress(MouseEventArgs e)
        {
            //call slicer
            List<Texture2D> _textures = Slicer.SliceTexture(_mainTexture, Game1._graphics.GraphicsDevice, _data.Columbs, _data.Rows, _data.CellSize);
          
            Slicer.SaveTextureAsPng(_textures, _data.DefaultName);
        }
        private void LoadImage(MouseEventArgs e)
        {
            //load an image
            this._mainTexture = IO.LoadTexture2D();
        }

        public override void Draw(GameTime gameTime)
        {
            if(_mainTexture == null){return;}

            Game1._spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.Main.TransformMatrix);

            Game1._spriteBatch.Draw(_mainTexture, Vector2.Zero, Color.White);

            Game1._spriteBatch.End();
        }
    }
}


