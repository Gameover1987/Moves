using Moves.Engine.Board;
using Moves.Engine.Figures;

namespace Moves.Game.ViewModels.Board
{
    public interface IBoardViewModel
    {
        IChessBoardCellViewModel[] Cells { get; }

        ChessFigureType? AddingFigure { get; set; }

        void PerformHitTest(string positionStr);
    }
}