using Moves.Engine.Board;
using Moves.Engine.Figures;

namespace Moves.Game.ViewModels.Board
{
    public interface IBoardViewModel
    {
        IChessBoardCellViewModel[] Cells { get; }

        FigureColor CurrentColor { get; set; }

        ChessFigureType? AddingFigure { get; set; }

        BoardHitTestResult PerformHitTest(string positionStr);

        void SetFigure(Position position);
    }
}