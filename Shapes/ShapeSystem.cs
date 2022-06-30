using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpriteSlicer.src;

namespace SpriteSlicer.Shapes
{
    public class ShapeSystem : DrawableGameComponent
    {
        public static ShapeSystem Instance;
        private List<Rect> _shapes = new List<Rect>();
        private Texture2D _pixel;

        public ShapeSystem(Game _game) : base(_game)
        {
            _pixel = new Texture2D(this.Game.GraphicsDevice, 1,1);
            _pixel.SetData(new Color[] {Color.White});

            Instance = this;
        }

        public Rect AddRect(Vector2 _pos, Vector2 _size, int _lineThickness = 1)
        {
            Rect _rect = new Rect(_pixel, _pos, _size, _lineThickness);
            _shapes.Add(_rect);
            return _rect;
        }

        public void Clear()
        {
            _shapes.Clear();
        }

        public override void Draw(GameTime gameTime)
        {
            Game1._spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.Main.TransformMatrix);

            for (int i = 0; i < _shapes.Count; i++)
            {
                _shapes[i].Draw(Game1._spriteBatch);
            }

            Game1._spriteBatch.End();
        }


    }
}


