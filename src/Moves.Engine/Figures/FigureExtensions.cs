using System;

namespace Moves.Engine.Figures
{
    public static class FigureExtensions
    {
        public static IFigure CreateFigure(this ChessFigureType chessFigure, Position position)
        {
            return chessFigure.CreateFigure(position.ToString());
        }

        public static IFigure CreateFigure(this ChessFigureType chessFigure, string positionStr)
        {
            switch (chessFigure)
            {
                case ChessFigureType.Pawn:
                    return new Pawn(positionStr);

                case ChessFigureType.Rook:
                    return new Rook(positionStr);

                case ChessFigureType.Knight:
                    return new Knight(positionStr);

                case ChessFigureType.Bishop:
                    return new Bishop(positionStr);

                case ChessFigureType.King:
                    return new King(positionStr);

                case ChessFigureType.Queen:
                    return new Queen(positionStr);

                default:
                    throw new NotSupportedException("Неизвестный тип фигуры");
            }
        }
    }
}
