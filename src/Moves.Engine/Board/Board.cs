using System.Collections.Generic;
using System.Linq;
using Moves.Engine.Figures;

namespace Moves.Engine.Board
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
            var attackedFigures = new List<IFigure>();

            var sourceFigureMoves = figure.GetMoves(this);

            foreach (var figureOnBoard in _figures)
            {
                var moves = figureOnBoard.GetMoves(this);
                if (moves.Any(x => x.Equals(figure.Position)))
                {
                    attackingFigures.Add(figureOnBoard);
                }                
            }

            return new BoardHitTestResult
            {
                ResultFor = figure,
                AttackingFigures = attackingFigures
                    .OrderBy(x=>x.Position.PositionStr)
                    .ToArray(),

                AttackedFigures = _figures
                    .Where(x => sourceFigureMoves.Contains(x.Position))
                    .OrderBy(x => x.Position.PositionStr)
                    .ToArray()
            };
        }
    }
}