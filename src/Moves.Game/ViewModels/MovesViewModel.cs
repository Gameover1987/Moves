using Moves.Game.Interaction;
using Moves.Game.ViewModels.Board;
using Moves.Game.ViewModels.Commands;

namespace Moves.Game.ViewModels
{
    public sealed class MovesViewModel : ViewModelBase, IMovesViewModel
    {
        private readonly IViewManager _viewManager;

        private IPlayerViewModel _player1;
        private IPlayerViewModel _player2;
        private readonly IBoardViewModel _board;

        public MovesViewModel(IViewManager viewManager, IBoardViewModel board)
        {
            _viewManager = viewManager;
            _board = board;

            NewGameCommand = new NotifyCommand(NewGameCommandHandler);            
        }

        public IPlayerViewModel Player1
        {
            get { return _player1; }
            set { SetProperty(() => _player1, value); }
        }

        public IPlayerViewModel Player2
        {
            get { return _player2; }
            set { SetProperty(() => _player2, value); }
        }

        public IBoardViewModel Board
        {
            get { return _board; }
        }

        public INotifyCommand NewGameCommand { get; private set; }

        private void NewGameCommandHandler()
        {
            var newGameViewModel = _viewManager.NewGame();
            if (newGameViewModel == null)
                return;

            Player1 = newGameViewModel.Player1;
            Player2 = newGameViewModel.Player2;
        }
    }
}
