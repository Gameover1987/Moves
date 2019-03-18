namespace Moves.Engine
{
    public sealed class Figure : IFigure
    {
        public Figure(FigureType type, FigureColor color, string position)
        {
            Type = type;
            Color = color;
            Position = new Position(position);
        }

        public FigureColor Color { get; }

        public Position Position { get; }

        public FigureType Type { get; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Color, Type, Position.PositionStr);
        }

        public override bool Equals(object obj)
        {
            var figure = obj as IFigure;
            if (figure == null)
                return false;

            return figure.ToString().Equals(ToString());
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}