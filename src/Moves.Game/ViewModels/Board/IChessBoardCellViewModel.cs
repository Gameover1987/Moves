using Moves.Engine.Figures;

namespace Moves.Game.ViewModels.Board
{
    public interface IChessBoardCellViewModel
    {
        int Row { get; }
        int Column { get; }
        FigureColor Color { get; }
        IFigureViewModel Figure { get; set; }
    }
}