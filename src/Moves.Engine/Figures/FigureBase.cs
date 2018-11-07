using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public abstract class FigureBase : IFigure
    {
        protected FigureBase(string position)
        {
            Position = new Position(position);
        }

        public FigureColor Color { get; set; }

        public Position Position { get; set; }

        public abstract Position[] GetMoves(IBoard board);

        public override string ToString()
        {
            return string.Format("{0} {1}", this.GetType().Name, Position.PositionStr);
        }

        public override bool Equals(object obj)
        {
            var figure = obj as IFigure;
            if (figure == null)
                return false;

            return figure.ToString().Equals(ToString());
        }
    }
}