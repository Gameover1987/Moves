using System.Collections.Generic;
using System.Linq;
using Moves.Engine.Board;

namespace Moves.Engine.Figures
{
    public class Knight : FigureBase
    {
        public Knight(string position)
            : base(position)
        {
        }

        public override ChessFigureType Type => ChessFigureType.Knight;

        protected override Position[] GetMovesImpl(IBoard board)
        {
            var allMoves = new List<Position>();
            allMoves.Add(new Position(Position.Column - 2, Position.Row + 1));
            allMoves.Add(new Position(Position.Column - 1, Position.Row + 2));
            allMoves.Add(new Position(Position.Column + 2, Position.Row + 1));
            allMoves.Add(new Position(Position.Column + 1, Position.Row + 2));
            allMoves.Add(new Position(Position.Column + 2, Position.Row - 1));
            allMoves.Add(new Position(Position.Column + 1, Position.Row - 2));
            allMoves.Add(new Position(Position.Column - 1, Position.Row - 2));
            allMoves.Add(new Position(Position.Column - 2, Position.Row - 1));

            var posibleMoves = allMoves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }
    }
}