using System.Collections.Generic;
using System.Linq;
using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public sealed class Queen : FigureBase
    {
        public Queen(string position) 
            : base(position)
        {
        }

        protected override Position[] GetMovesImpl(IBoard board)
        {
            var verticalRookMoves = new List<Position>();
            for (int i = 1; i <= board.Height; i++)
            {
                verticalRookMoves.Add(new Position(Position.Column, i));
            }

            var horizontalRookMoves = new List<Position>();
            for (int i = 1; i <= board.Width; i++)
            {
                horizontalRookMoves.Add(new Position(i, Position.Row));
            }

            var rookMoves = verticalRookMoves.Concat(horizontalRookMoves);

            var bishopMoves = new List<Position>();
            for (int i = 1; i < board.Width; i++)
            {
                bishopMoves.Add(new Position(Position.Column - i, Position.Row - i));
                bishopMoves.Add(new Position(Position.Column + i, Position.Row - i));
                bishopMoves.Add(new Position(Position.Column - i, Position.Row + i));
                bishopMoves.Add(new Position(Position.Column + i, Position.Row + i));
            }

            var allQueenMoves = rookMoves.Concat(bishopMoves);

            var posibleMoves = allQueenMoves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .Where(x => !x.Equals(Position))
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }
    }
}
