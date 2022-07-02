using System;
using System.IO;
using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteSlicer.src
{
    public static class IO
    {
        public static Texture2D LoadTexture2D()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Users";
            ofd.Multiselect = false;

            Texture2D _texture = null;

            if(ofd.ShowDialog() == DialogResult.OK)
            {
                _texture = Texture2D.FromFile(Game1._graphics.GraphicsDevice, ofd.FileName);

                return _texture;
            }

            return null;
        }
    }
}


