using Robot.Environment;

namespace Robot.Vision
{
    public class Vision
    {

        public Ball Ball { get; set; }
        public Goal Goal { get; set; }
        public Field Field { get; set; }
        public Player RivalPlayer { get; set; }
        public Player OurPlayer { get; set; }
        public RivalPlayerColor DefultRivalPlayerColor { get; set; }

        public enum RivalPlayerColor
        {
            Magenta,
            Cyan
        }

        public Vision()
        {
            Ball = new Ball();
            Goal = new Goal();
            Field = new Field();
            RivalPlayer = new Player();
            OurPlayer = new Player();
            DefultRivalPlayerColor = RivalPlayerColor.Cyan;
            LoadColors(DefultRivalPlayerColor);
        }

        public void LoadColors(RivalPlayerColor rivalPlayerColor)
        {
            if (rivalPlayerColor == RivalPlayerColor.Magenta)
            {

                RivalPlayer.Color.Load("ColorSpaces\\Magenta.xml");
                OurPlayer.Color.Load("ColorSpaces\\Cyan.xml");
            }
            if (rivalPlayerColor == RivalPlayerColor.Cyan)
            {
                RivalPlayer.Color.Load("ColorSpaces\\Cyan.xml");
                OurPlayer.Color.Load("ColorSpaces\\Magenta.xml");
            }

            Goal.Color.Load("ColorSpaces\\Goal.xml");
            Ball.Color.Load("ColorSpaces\\Ball.xml");
            Ball.Color2.Load("ColorSpaces\\Ball2.xml");
            Ball.Color3.Load("ColorSpaces\\Ball3.xml");
            Ball.Color4.Load("ColorSpaces\\Ball4.xml");
            Field.Color.Load("ColorSpaces\\Field.xml");
        }
    }
}
