using System;
using System.Linq;
using Moves.Engine.Figures;

namespace Moves.Engine.Tests
{
    public static class TestUtils
    {
        public static Position[] ToPositions(this string positionStr)
        {
            var positions = positionStr.Split(' ').Select(x => new Position(x)).OrderBy(x => x.PositionStr).ToArray();
            return positions;
        }

        public static IFigure[] ToFigures(this string figuresStr, FigureColor color)
        {
            if (string.IsNullOrWhiteSpace(figuresStr))
                return Enumerable.Empty<IFigure>().ToArray();

            var figures = figuresStr.Split(' ').Select(x => x.ToFigure(color)).OrderBy(x => x.Position.PositionStr).ToArray();
            return figures;
        }

        public static IFigure ToFigure(this string figureStr, FigureColor color)
        {
            var figureLetter = figureStr[0].ToString();
            var positionStr = figureStr.Substring(1);
            IFigure figure = null;
            switch (figureLetter)
            {
                case "P":
                    figure = new Pawn(positionStr);
                    break;

                case "R":
                    figure = new Rook(positionStr);
                    break;

                case "N":
                    figure = new Knight(positionStr);
                    break;

                case "B":
                    figure = new Bishop(positionStr);
                    break;

                case "K":
                    figure = new King(positionStr);
                    break;

                case "Q":
                    figure = new Queen(positionStr);
                    break;

                default:
                    throw new NotSupportedException("Неизвестный тип фигуры");
            }

            figure.Color = color;
            return figure;
        }
    }
}
