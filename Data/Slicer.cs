using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteSlicer.Data
{
    public static class Slicer
    {
        public static Texture2D SliceTexture(Texture2D src, GraphicsDevice graphics, Rectangle rect)
        {
            //https://stackoverflow.com/questions/44760512/xna-make-a-new-texture2d-out-of-another-texture2d
            Texture2D tex = new Texture2D(graphics, rect.Width, rect.Height);
            int count = rect.Width * rect.Height;
            Color[] data = new Color[count];
            src.GetData(0, rect, data, 0, count);
            tex.SetData(data);
            return tex;
        }

        public static List<Texture2D> SliceTexture(Texture2D src, GraphicsDevice graphics, List<Rectangle> rects)
        {
            List<Texture2D> _textures = new List<Texture2D>();

            foreach (var item in rects)
            {
                _textures.Add(SliceTexture(src, graphics, item));
            }
            return _textures;
        }

        public static List<Texture2D> SliceTexture(Texture2D src, GraphicsDevice graphics, int columbs, int rows, Vector2 cellSize)
        {
            List<Texture2D> _textures = new List<Texture2D>();

            for (int x = 0; x < columbs; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    int xOffset = (int)(x * cellSize.X);
                    int yOffset = (int)(y * cellSize.Y);

                    Rectangle _r = new Rectangle(xOffset, yOffset, (int)cellSize.X, (int)cellSize.Y);

                    _textures.Add(SliceTexture(src, graphics, _r));
                }
            }

            return _textures;
        }

        public static void SaveTextureAsPng(Texture2D _texture, string _fileName)
        {
            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.FileName = _fileName;


            if(_sfd.ShowDialog() == DialogResult.OK)
            {
                string _path = Path.Combine(_sfd.FileName, _fileName) + ".png";
                Stream stream = File.Create(_path); 
                _texture.SaveAsPng( stream, _texture.Width, _texture.Height );
                stream.Dispose();
                _texture.Dispose();
            }
        }

        public static void SaveTextureAsPng(List<Texture2D> _textures, string _fileName)
        {
            SaveFileDialog _sfd = new SaveFileDialog();
            _sfd.FileName = _fileName;


            if(_sfd.ShowDialog() == DialogResult.OK)
            {
                System.Console.WriteLine("Slicer: SaveTextureAsPng: TextureCount" +  _textures.Count);

                int i = 0;
                foreach (var _texture in _textures)
                {
                    string _path = _sfd.FileName + $"_{i}.png";
                    System.Console.WriteLine("File Name: " + _path);
                    Stream stream = File.Create(_path); 
                    _texture.SaveAsPng( stream, _texture.Width, _texture.Height );
                    stream.Dispose();
                    _texture.Dispose();  

                    i += 1;                  
                }
            }
        }


        /*public static void SaveTextureAsJpeg(Texture2D _texture, string _fileName)
        {
            string _path = Path.Combine(EditorFileManager.Instance.Content_Img, _fileName) + ".png";
            Stream stream = File.Create(_path);
            _texture.SaveAsJpeg( stream, _texture.Width, _texture.Height );
            stream.Dispose();
            _texture.Dispose();
        }*/
    }
}


