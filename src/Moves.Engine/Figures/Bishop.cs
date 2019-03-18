using System;
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

        public override ChessFigureType Type => ChessFigureType.Bishop;

        protected override Position[] GetMovesImpl(IBoard board)
        {
            var moves = new List<Position>();

            // Right Top
            var column = Position.Column;
            var row = Position.Row;
            while (CanMove(board, column, row))
            {
                column++;
                row++;
                var position = new Position(column, row);
                if (AddMove(board, position, moves))
                    break;
            }

            // Right Bottom
            column = Position.Column;
            row = Position.Row;
            while (CanMove(board, column, row))
            {
                column++;
                row--;
                var position = new Position(column, row);
                if (AddMove(board, position, moves))
                    break;
            }


            return moves.ToArray();
        }

        //private bool CanMove(IBoard board, int column, int row)
        //{
        //    return column > 0 && column <= board.Width &&
        //           row > 0 && row <= board.Height;
        //}
    }
}
