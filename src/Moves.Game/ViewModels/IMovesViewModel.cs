using Moves.Game.ViewModels.Board;
using Moves.Game.ViewModels.Commands;

namespace Moves.Game.ViewModels
{
    public interface IMovesViewModel
    {
        IPlayerViewModel Player1 { get; }
        IPlayerViewModel Player2 { get; }
        IBoardViewModel Board { get; }

        INotifyCommand NewGameCommand { get;  }
    }
}