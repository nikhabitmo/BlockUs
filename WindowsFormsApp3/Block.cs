using System.Drawing;

namespace WindowsFormsApp3
{
    public class Block
    {
        public bool[,] Shape { get; }
        public Color Color { get; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Player { get; set; }

        public Block(bool[,] shape, int player, Color color)
        {
            Shape = shape;
            Color = color;
            Player = player;
            Width = shape.GetLength(0);
            Height = shape.GetLength(1);
        }
    }
}