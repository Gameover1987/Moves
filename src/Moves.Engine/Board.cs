using System;
using System.Collections.Generic;
using System.Linq;

namespace Moves.Engine
{
    public class Board : IBoard
    {
        private readonly List<IFigure> _figures = new List<IFigure>(GlobalConstants.DefaultWidth * GlobalConstants.DefaultHeight);

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public static IBoard CreateDefault()
        {
            return new Board(GlobalConstants.DefaultWidth, GlobalConstants.DefaultHeight);
        }

        public IEnumerable<IFigure> Figures => _figures;

        public int Width { get; }

        public int Height { get; }

        public void AddFigure(IFigure figure)
        {
            _figures.Add(figure);
        }

        public BoardHitTestResult HitTest(IFigure figure)
        {
            var attackingFigures = new List<IFigure>();

            var sourceFigureMoves = GetMoves(figure);

            var figuresToCheck = _figures.Where(x => x.Color != figure.Color).ToArray();
            foreach (var figureOnBoard in figuresToCheck)
            {
                var moves = GetMoves(figureOnBoard);
                if (moves.Any(x => x.Equals(figure.Position)))
                {
                    attackingFigures.Add(figureOnBoard);
                }
            }

            var result = new BoardHitTestResult
            {
                ResultFor = figure,
                AttackingFigures = attackingFigures
                    .OrderBy(x => x.Position.PositionStr)
                    .ToArray(),

                AttackedFigures = figuresToCheck
                    .Where(x => sourceFigureMoves.Contains(x.Position))
                    .OrderBy(x => x.Position.PositionStr)
                    .ToArray()
            };

            return result;
        }

        public Position[] GetMoves(IFigure figure)
        {
            switch (figure.Type)
            {
                case FigureType.Pawn:
                    return this.GetPawnMoves(figure);
                case FigureType.Rook:
                    return this.GetRookMoves(figure);
                case FigureType.Knight:
                    return this.GetKnightMoves(figure);
                case FigureType.Bishop:
                    return this.GetBishopMoves(figure);
                case FigureType.Queen:
                    return this.GetQueenMoves(figure);
                case FigureType.King:
                    return this.GetKingMoves(figure);
                default:
                    throw new ArgumentException("Unknown type of figure");
            }
        }

        public IFigure GetFigureByPosition(string positionStr)
        {
            return _figures.FirstOrDefault(x => x.Position.PositionStr == positionStr);
        }
    }
}