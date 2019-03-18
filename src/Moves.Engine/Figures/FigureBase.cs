using System.Collections.Generic;
using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public abstract class FigureBase : IFigure
    {
        protected bool _isPositionChanged;

        protected Position _position;

        protected Position[] _moves;

        protected FigureBase(string position)
        {
            Position = new Position(position);
        }

        public FigureColor Color { get; set; }

        public Position Position
        {
            get { return _position; }
            set
            {
                if (_position == value)
                    return;
                _position = value;
                _isPositionChanged = true;
            }
        }

        public Position[] GetMoves(IBoard board)
        {
            if (_isPositionChanged)
                _moves = GetMovesImpl(board);

            _isPositionChanged = false;
            return _moves;
        }

        public abstract ChessFigureType Type { get; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Color, GetType().Name, Position.PositionStr);
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

        protected abstract Position[] GetMovesImpl(IBoard board);

        protected bool AddMove(IBoard board, Position position, List<Position> moves)
        {
            var figureByPosition = board.GetFigureByPosition(position.PositionStr);
            if (figureByPosition != null)
            {
                if (figureByPosition.Color != Color)
                {
                    moves.Add(position);
                }

                return true;
            }

            moves.Add(position);
            return false;
        }
    }
}