using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteSlicer.Shapes
{
    public class Rect
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Size;
        public Color DrawColor = Color.White;
        public int LineThickness;
        private Rectangle _sourceRect;

        public Rect(Texture2D _texture, Vector2 _pos, Vector2 _size, int _lineThickness)
        {
            this.Texture = _texture;
            this.Position = _pos;
            this.Size = _size;
            this.LineThickness = _lineThickness;

            _sourceRect = new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);
        }
        public void Draw(SpriteBatch _spritebatch)
        {
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Top, _sourceRect.Width, LineThickness), DrawColor);//top
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Right, _sourceRect.Top, LineThickness, _sourceRect.Height), DrawColor);//right
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Bottom, _sourceRect.Width + LineThickness, LineThickness), DrawColor);//bottom
            _spritebatch.Draw(Texture, new Rectangle(_sourceRect.Left, _sourceRect.Top, LineThickness, _sourceRect.Height), DrawColor);//left
        }
    }
}


