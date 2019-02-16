using System.Collections.Generic;
using System.Linq;
using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public sealed class Rook : FigureBase
    {
        public Rook(string position) 
            : base(position)
        {
        }

        public override ChessFigureType Type => ChessFigureType.Rook;

        protected override Position[] GetMovesImpl(IBoard board)
        {
            var verticalMoves = new List<Position>();
            for (int i = 1; i <= board.Height; i++)
            {
                verticalMoves.Add(new Position(Position.Column, i));
            }

            var horizontalMoves = new List<Position>();
            for (int i = 1; i <= board.Width; i++)
            {
                horizontalMoves.Add(new Position(i, Position.Row));
            }

            var posibleMoves = verticalMoves
                .Concat(horizontalMoves)
                .OrderBy(x => x.PositionStr)
                .Where(x => !x.Equals(Position))
                .ToArray();

            return posibleMoves;
        }
    }
}
