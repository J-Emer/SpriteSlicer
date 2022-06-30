using Microsoft.Xna.Framework;

namespace SpriteSlicer.Data
{
    public class SlicerData
    {
        public int Columbs{get;set;} = 1;
        public int Rows{get;set;} = 1;
        public Vector2 CellSize{get;set;} = new Vector2(16,16);
        public string DefaultName{get;set;} = "Sprite";
    }
}


