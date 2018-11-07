using System.Collections.Generic;
using System.Linq;
using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public sealed class Pawn : FigureBase
    {
        public Pawn(string position)
            : base(position)
        {
        }

        public override Position[] GetMoves(IBoard board)
        {
            var moves = new List<Position>();
            if (Color == FigureColor.White)
            {
                moves.Add(new Position(Position.Column - 1, Position.Row + 1));
                moves.Add(new Position(Position.Column + 1, Position.Row + 1));
            }
            else if (Color == FigureColor.Black)
            {
                moves.Add(new Position(Position.Column - 1, Position.Row - 1));
                moves.Add(new Position(Position.Column + 1, Position.Row - 1));
            }

            var posibleMoves = moves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }
    }
}
