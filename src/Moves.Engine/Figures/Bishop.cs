using System.Collections.Generic;
using System.Linq;
using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public sealed class Bishop : FigureBase
    {
        public Bishop(string position)
            : base(position)
        {
        }

        protected override Position[] GetMovesImpl(IBoard board)
        {
            var allMoves = new List<Position>();
            for (int i = 1; i < board.Width; i++)
            {
                allMoves.Add(new Position(Position.Column - i, Position.Row - i));
                allMoves.Add(new Position(Position.Column + i, Position.Row - i));
                allMoves.Add(new Position(Position.Column - i, Position.Row + i));
                allMoves.Add(new Position(Position.Column + i, Position.Row + i));
            }

            var posibleMoves = allMoves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }
    }
}
