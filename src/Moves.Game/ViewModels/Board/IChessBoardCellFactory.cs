using Moves.Engine.Figures;

namespace Moves.Game.ViewModels.Board
{
    public interface IChessBoardCellFactory
    {
        IChessBoardCellViewModel CreateCell(int row, int col);
    }

    public class ChessBoardCellFactory : IChessBoardCellFactory
    {
        public IChessBoardCellViewModel CreateCell(int row, int col)
        {
            var color = (row + col) % 2 == 1 ? FigureColor.White : FigureColor.Black;
            return new ChessBoardCellViewModel(row, col, color);
        }
    }
}