using Moves.Engine;
using Moves.Game.ViewModels.Board;
using Moves.Game.ViewModels.Commands;

namespace Moves.Game.ViewModels
{
    public interface IMovesViewModel
    {
        IPlayerViewModel Player1 { get; }
        IPlayerViewModel Player2 { get; }
        IBoardViewModel Board { get; }
        IPlayerViewModel ActivePlayer { get; }

        INotifyCommand NewGameCommand { get;  }

        string GameInfo { get; }

        void DoMove(Position position);
    }
}