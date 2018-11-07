using System.Collections.Generic;
using System.Linq;
using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public sealed class King : FigureBase
    {
        public King(string position)
            : base(position)
        {
        }

        public override Position[] GetMoves(IBoard board)
        {
            var allMoves = new List<Position>();
            allMoves.Add(new Position(Position.Column - 1, Position.Row - 1));
            allMoves.Add(new Position(Position.Column - 0, Position.Row - 1));
            allMoves.Add(new Position(Position.Column + 1, Position.Row - 1));
            allMoves.Add(new Position(Position.Column - 1, Position.Row - 0));
            allMoves.Add(new Position(Position.Column + 1, Position.Row - 0));
            allMoves.Add(new Position(Position.Column - 1, Position.Row + 1));
            allMoves.Add(new Position(Position.Column - 0, Position.Row + 1));
            allMoves.Add(new Position(Position.Column + 1, Position.Row + 1));
            
            var posibleMoves = allMoves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }
    }
}
