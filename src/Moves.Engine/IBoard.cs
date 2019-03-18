using System.Collections.Generic;

namespace Moves.Engine
{
    public interface IBoard
    {
        IEnumerable<IFigure> Figures { get; }

        int Width { get; }

        int Height { get; }

        void AddFigure(IFigure figure);

        BoardHitTestResult HitTest(IFigure figure);

        Position[] GetMoves(IFigure figure);
    }
}
