using System;
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
            var moves = new List<Position>();

            // По вертикали вверх
            for (int i = Position.Row + 1; i <= board.Height; i++)
            {
                var position = new Position(Position.Column, i);
                if (AddMove(board, position, moves))
                    break;
            }

            // По вертикали вниз
            for (int i = Position.Row - 1; i > 0; i--)
            {
                var position = new Position(Position.Column, i);
                if (AddMove(board, position, moves))
                    break;
            }

            // По горизонтали вправо
            for (int i = Position.Column + 1; i <= board.Width; i++)
            {
                var position = new Position(i, Position.Row);
                if (AddMove(board, position, moves))
                    break;
            }

            // По горизонтали влево
            for (int i = Position.Column - 1; i > 0; i--)
            {
                var position = new Position(i, Position.Row);
                if (AddMove(board, position, moves))
                    break;
            }

            var posibleMoves = moves
                .OrderBy(x => x.PositionStr)
                .Where(x => !x.Equals(Position))
                .ToArray();

            return posibleMoves;
        }
    }
}
