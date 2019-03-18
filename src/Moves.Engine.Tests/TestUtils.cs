using System;
using System.Linq;

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
                    figure = new Figure(FigureType.Pawn, color, positionStr);
                    break;

                case "R":
                    figure = new Figure(FigureType.Rook, color, positionStr);
                    break;

                case "N":
                    figure = new Figure(FigureType.Knight, color, positionStr);
                    break;

                case "B":
                    figure = new Figure(FigureType.Bishop, color, positionStr);
                    break;

                case "K":
                    figure = new Figure(FigureType.King, color, positionStr);
                    break;

                case "Q":
                    figure = new Figure(FigureType.Queen, color, positionStr);
                    break;

                default:
                    throw new NotSupportedException("Неизвестный тип фигуры");
            }
            
            return figure;
        }
    }
}
