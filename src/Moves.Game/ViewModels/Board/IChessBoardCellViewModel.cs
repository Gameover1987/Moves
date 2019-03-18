using Moves.Engine;

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

        Position ToPosition();
    }

    public static class ChessBoardCellViewModelExtensions
    {
        public static Position ToPostion(this IChessBoardCellViewModel cell)
        {
            return new Position(cell.Column, cell.Row);
        }
    }
}