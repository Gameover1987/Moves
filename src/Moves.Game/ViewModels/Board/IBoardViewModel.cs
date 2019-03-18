using Moves.Engine;

namespace Moves.Game.ViewModels.Board
{
    public interface IBoardViewModel
    {
        IChessBoardCellViewModel[] Cells { get; }

        FigureColor CurrentColor { get; set; }

        FigureType? AddingFigure { get; set; }

        BoardHitTestResult PerformHitTest(string positionStr);

        void SetFigure(IFigure figure);
    }
}