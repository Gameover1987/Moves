using System.Collections.Generic;
using Moves.Engine.Figures;

namespace Moves.Engine.Board
{
    public interface IBoard
    {
        IEnumerable<IFigure> Figures { get; }

        int Width { get; }

        int Height { get; }

        void AddFigure(IFigure figure);

        BoardHitTestResult HitTest(IFigure figure);
    }
}
