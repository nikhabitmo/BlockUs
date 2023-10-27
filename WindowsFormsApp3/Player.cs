using System.Drawing;

namespace WindowsFormsApp3
{
    public class Player
    {
        public string Name { get; }
        private Color color1;
        private Color color2;
        private bool usingColor1;

        public Player(string name, Color color1, Color color2)
        {
            Name = name;
            this.color1 = color1;
            this.color2 = color2;
            usingColor1 = true;
        }

        public Color GetCurrentColor()
        {
            if (usingColor1)
            {
                usingColor1 = false;
                return color1;
            }
            else
            {
                usingColor1 = true;
                return color2;
            }
        }
    }
}