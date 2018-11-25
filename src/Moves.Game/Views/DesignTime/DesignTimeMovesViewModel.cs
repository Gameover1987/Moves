using Moves.Game.ViewModels;
using Moves.Game.ViewModels.Board;
using Moves.Game.ViewModels.Commands;

namespace Moves.Game.Views.DesignTime
{
    internal sealed class DesignTimeMovesViewModel : IMovesViewModel
    {
        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public IBoardViewModel Board { get; private set; }

        public INotifyCommand NewGameCommand { get; private set; }
    }
}
