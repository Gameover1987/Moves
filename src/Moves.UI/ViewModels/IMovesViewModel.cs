using Moves.UI.ViewModels.Commands;

namespace Moves.UI.ViewModels
{
    public interface IMovesViewModel
    {
        IPlayerViewModel Player1 { get; }
        IPlayerViewModel Player2 { get; }
        IBoardViewModel Board { get; }

        INotifyCommand NewGameCommand { get;  }
    }
}