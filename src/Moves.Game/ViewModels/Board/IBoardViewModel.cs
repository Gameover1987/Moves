namespace Moves.Game.ViewModels.Board
{
    public interface IBoardViewModel
    {
        IChessBoardCellViewModel[] Cells { get; }
    }
}