namespace Moves.UI.ViewModels
{
    public interface IMovesViewModel
    {
        IPlayerViewModel Player1 { get; }
        IPlayerViewModel Player2 { get; }
        IBoardViewModel Board { get; }

    }
}