using Moves.Engine.Figures;

namespace Moves.Engine.Board
{
    public class BoardHitTestResult
    {
        public IFigure ResultFor { get; set; }

        public IFigure[] AttackingFigures { get; set; }

        public IFigure[] AttackedFigures { get; set; }
    }
}