using Moves.Engine.Figures;

namespace Moves.Game.ViewModels.Board
{
    public enum CellState
    {
        None,
        Green,
        Red
    }

    public interface IChessBoardCellViewModel
    {
        int Row { get; }

        int Column { get; }

        FigureColor Color { get; }

        IFigure Figure { get; set; }

        CellState State { get; set; }
    }
}