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

        public static IFigure[] ToFigures(this string figuresStr)
        {
            if (string.IsNullOrWhiteSpace(figuresStr))
                return Enumerable.Empty<IFigure>().ToArray();

            var figures = figuresStr.Split(' ').Select(x => x.ToFigure()).OrderBy(x => x.Position.PositionStr).ToArray();
            return figures;
        }

        public static IFigure ToFigure(this string figureStr)
        {
            var figureLetter = figureStr[0].ToString().ToUpper();
            var positionStr = figureStr.Substring(1);
            switch (figureLetter)
            {
                case "P":
                    return new Pawn(positionStr);

                case "R":
                    return new Rook(positionStr);

                case "N":
                    return new Knight(positionStr);

                case "B":
                    return new Bishop(positionStr);

                case "K":
                    return new King(positionStr);

                case "Q":
                    return new Queen(positionStr);

                default:
                    throw new NotSupportedException("Неизвестный тип фигуры");
            }
        }
    }
}
