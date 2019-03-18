using System.Collections.Generic;
using System.Linq;

namespace Moves.Engine
{
    public static class MoveStrategy
    {
        public static Position[] GetPawnMoves(this IBoard board, IFigure figure)
        {
            var moves = new List<Position>();
            if (figure.Color == FigureColor.White)
            {
                moves.Add(new Position(figure.Position.Column - 1, figure.Position.Row + 1));
                moves.Add(new Position(figure.Position.Column + 1, figure.Position.Row + 1));
            }
            else if (figure.Color == FigureColor.Black)
            {
                moves.Add(new Position(figure.Position.Column - 1, figure.Position.Row - 1));
                moves.Add(new Position(figure.Position.Column + 1, figure.Position.Row - 1));
            }

            var posibleMoves = moves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }

        public static Position[] GetRookMoves(this IBoard board, IFigure figure)
        {
            var moves = new List<Position>();

            // По вертикали вверх
            for (int i = figure.Position.Row + 1; i <= board.Height; i++)
            {
                var position = new Position(figure.Position.Column, i);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            // По вертикали вниз
            for (int i = figure.Position.Row - 1; i > 0; i--)
            {
                var position = new Position(figure.Position.Column, i);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            // По горизонтали вправо
            for (int i = figure.Position.Column + 1; i <= board.Width; i++)
            {
                var position = new Position(i, figure.Position.Row);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            // По горизонтали влево
            for (int i = figure.Position.Column - 1; i > 0; i--)
            {
                var position = new Position(i, figure.Position.Row);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            var posibleMoves = moves
                .OrderBy(x => x.PositionStr)
                .Where(x => !x.Equals(figure.Position))
                .ToArray();

            return posibleMoves;
        }

        public static Position[] GetKnightMoves(this IBoard board, IFigure figure)
        {
            var allMoves = new List<Position>();
            allMoves.Add(new Position(figure.Position.Column - 2, figure.Position.Row + 1));
            allMoves.Add(new Position(figure.Position.Column - 1, figure.Position.Row + 2));
            allMoves.Add(new Position(figure.Position.Column + 2, figure.Position.Row + 1));
            allMoves.Add(new Position(figure.Position.Column + 1, figure.Position.Row + 2));
            allMoves.Add(new Position(figure.Position.Column + 2, figure.Position.Row - 1));
            allMoves.Add(new Position(figure.Position.Column + 1, figure.Position.Row - 2));
            allMoves.Add(new Position(figure.Position.Column - 1, figure.Position.Row - 2));
            allMoves.Add(new Position(figure.Position.Column - 2, figure.Position.Row - 1));

            var posibleMoves = allMoves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }

        public static Position[] GetBishopMoves(this IBoard board, IFigure figure)
        {
            var moves = new List<Position>();

            // Right Top
            var column = figure.Position.Column;
            var row = figure.Position.Row;
            while (CanMove(board, column, row))
            {
                column++;
                row++;
                var position = new Position(column, row);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            // Right Bottom
            column = figure.Position.Column;
            row = figure.Position.Row;
            while (CanMove(board, column, row - 1))
            {
                column++;
                row--;
                var position = new Position(column, row);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            // Left Bottom
            column = figure.Position.Column;
            row = figure.Position.Row;
            while (CanMove(board, column - 1, row - 1))
            {
                column--;
                row--;
                var position = new Position(column, row);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            // Left Top
            column = figure.Position.Column;
            row = figure.Position.Row;
            while (CanMove(board, column - 1, row))
            {
                column--;
                row++;
                var position = new Position(column, row);
                if (AddMove(board, figure, position, moves))
                    break;
            }

            return moves.ToArray();
        }

        public static Position[] GetQueenMoves(this IBoard board, IFigure figure)
        {
            var rookMoves = board.GetRookMoves(figure);
            var bishopMoves = board.GetBishopMoves(figure);
            return rookMoves.Concat(bishopMoves).ToArray();
        }

        public static Position[] GetKingMoves(this IBoard board, IFigure figure)
        {
            var allMoves = new List<Position>();
            allMoves.Add(new Position(figure.Position.Column - 1, figure.Position.Row - 1));
            allMoves.Add(new Position(figure.Position.Column - 0, figure.Position.Row - 1));
            allMoves.Add(new Position(figure.Position.Column + 1, figure.Position.Row - 1));
            allMoves.Add(new Position(figure.Position.Column - 1, figure.Position.Row - 0));
            allMoves.Add(new Position(figure.Position.Column + 1, figure.Position.Row - 0));
            allMoves.Add(new Position(figure.Position.Column - 1, figure.Position.Row + 1));
            allMoves.Add(new Position(figure.Position.Column - 0, figure.Position.Row + 1));
            allMoves.Add(new Position(figure.Position.Column + 1, figure.Position.Row + 1));

            var posibleMoves = allMoves
                .Where(x => x.Column > 0 && x.Column <= board.Width && x.Row > 0 && x.Row <= board.Height)
                .OrderBy(x => x.PositionStr)
                .ToArray();

            return posibleMoves;
        }

        private static bool CanMove(IBoard board, int column, int row)
        {
            return column > 0 && column < board.Width &&
                   row > 0 && row < board.Height;
        }

        private static bool AddMove(IBoard board, IFigure figure, Position position, List<Position> moves)
        {
            var figureByPosition = board.Figures.FirstOrDefault(x => x.Position.PositionStr == position.PositionStr);
            if (figureByPosition != null)
            {
                if (figureByPosition.Color != figure.Color)
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
