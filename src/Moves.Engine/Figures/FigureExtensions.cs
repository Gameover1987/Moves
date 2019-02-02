using System;

namespace Moves.Engine.Figures
{
    public static class FigureExtensions
    {
        public static IFigure CreateFirgure(this ChessFigureType chessFigure, string position)
        {
            switch (chessFigure)
            {
                case ChessFigureType.Pawn:
                    return new Pawn(position);

                case ChessFigureType.Rook:
                    return new Rook(position);

                case ChessFigureType.Knight:
                    return new Knight(position);

                case ChessFigureType.Bishop:
                    return new Bishop(position);

                case ChessFigureType.King:
                    return new King(position);

                case ChessFigureType.Queen:
                    return new Queen(position);

                default:
                    throw new NotSupportedException("Неизвестный тип фигуры");
            }
        }
    }
}
