namespace _002_marsrovers
{
    public class Position
    {
        internal int X;
        internal int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void SetPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position GetPosition()
        {
            return this;
        }

        public override string ToString()
        {
            return X + ", " + Y;
        }

        public bool PositionIsDisctinct(Position position)
        {
            return (X != position.X || Y != position.Y);
        }
    }
}
