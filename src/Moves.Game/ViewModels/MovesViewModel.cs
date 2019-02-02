using Moves.Game.Interaction;
using Moves.Game.ViewModels.Board;
using Moves.Game.ViewModels.Commands;
using Moves.Game.Views.Converters;

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

            var newGame = new NewGameViewModel(new PlayerViewModelFactory());
            newGame.Initialize();
            newGame.GiveDefaultFigureSetCommand.Execute();
            Player1 = newGame.Player1;
            Player2 = newGame.Player2;

        }

        public IPlayerViewModel Player1
        {
            get => _player1;
            set
            {
                if (_player1 != null)
                    _player1.FigureSelected -= PlayerOnFigureSelected;

                _player1 = value;

                if (_player1 != null)
                    _player1.FigureSelected += PlayerOnFigureSelected;

                OnPropertyChanged(() => Player1);
            }
        }

        public IPlayerViewModel Player2
        {
            get => _player2;
            set
            {
                if (_player2 != null)
                    _player2.FigureSelected -= PlayerOnFigureSelected;

                _player2 = value;

                if (_player2 != null)
                    _player2.FigureSelected += PlayerOnFigureSelected;

                OnPropertyChanged(() => Player2);
            }
        }

        public string GameInfo
        {
            get
            {
                if (Player1 == null &&
                    Player2 == null)
                    return "Начните новую игру";

                if (Player1.SelectedFigure == null &&
                    Player2.SelectedFigure == null)
                    return string.Format("Ходит {0}", Player1.Nick);

                string playerName = null;
                if (Player1.SelectedFigure != null)
                {
                    return string.Format("Ходит {0}, выбрана '{1}'", Player1.Nick, Player1.SelectedFigure.Value.Localize());
                }
                else if (Player2.SelectedFigure != null)
                {
                    return string.Format("Ходит {0}, выбрана '{1}'", Player2.Nick, Player2.SelectedFigure.Value.Localize());
                }

                return null;
            }
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

        private void PlayerOnFigureSelected(object sender, FigureSelectedEventArgs e)
        {
            var player = (IPlayerViewModel)sender;
            if (player == Player1)
            {
                Player2.SelectedFigure = null;
            }
            else if (player == Player2)
            {
                Player1.SelectedFigure = null;
            }

            Board.AddingFigure = player.SelectedFigure;

            OnPropertyChanged(() => GameInfo);
        }
    }
}
