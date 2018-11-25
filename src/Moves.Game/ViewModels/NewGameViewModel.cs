using Moves.Engine.Figures;
using Moves.Game.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Moves.Game.Views.Windows;

namespace Moves.Game.ViewModels
{
    public sealed class NewGameViewModel : ViewModelBase, INewGameViewModel
    {
        private readonly IPlayerViewModelFactory _playerViewModelFactory;
        private ObservableCollection<ChessFigureType> _figures;
        private ChessFigureType _selectedFigure;

        public NewGameViewModel(IPlayerViewModelFactory playerViewModelFactory)
        {
            _playerViewModelFactory = playerViewModelFactory;
            GiveFigureToPlayer1Command = new NotifyCommand(GiveFigureToPlayer1CommandHandler);
            GiveFigureToPlayer2Command = new NotifyCommand(GiveFigureToPlayer2CommandHandler);
            GiveDefaultFigureSetCommand = new NotifyCommand(GiveDefaultFigureSetCommandHandler);
            OkCommand = new NotifyCommand(o => OkCommandHandler((IWindow)o), o => CanOkCommandHandler());
        }

        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public ObservableCollection<ChessFigureType> Figures { get { return _figures; } }

        public ChessFigureType SelectedFigure
        {
            get => _selectedFigure;
            set
            {
                SetProperty(() => _selectedFigure, value);
            }
        }

        public INotifyCommand GiveFigureToPlayer1Command { get; private set; }

        public INotifyCommand GiveFigureToPlayer2Command { get; private set; }

        public INotifyCommand GiveDefaultFigureSetCommand { get; private set; }

        public INotifyCommand OkCommand { get; private set; }

        public void Initialize()
        {
            Player1 = _playerViewModelFactory.CreatePlayer();
            Player2 = _playerViewModelFactory.CreatePlayer();
            
            _figures = new ObservableCollection<ChessFigureType>(Enum.GetValues(typeof(ChessFigureType)).Cast<ChessFigureType>());
        }

        private void GiveFigureToPlayer1CommandHandler()
        {
            Player1.Figures.Add(SelectedFigure);
        }

        private void GiveFigureToPlayer2CommandHandler()
        {
            Player2.Figures.Add(SelectedFigure);
        }

        private void GiveDefaultFigureSetCommandHandler()
        {
            Player1.Figures.Clear();
            Player2.Figures.Clear();

            for (var i = 0; i < 8; i++)
            {
                Player1.Figures.Add(ChessFigureType.Pawn);
                Player2.Figures.Add(ChessFigureType.Pawn);
            }

            for (int i = 0; i < 2; i++)
            {
                Player1.Figures.Add(ChessFigureType.Rook);
                Player1.Figures.Add(ChessFigureType.Knight);
                Player1.Figures.Add(ChessFigureType.Bishop);

                Player2.Figures.Add(ChessFigureType.Rook);
                Player2.Figures.Add(ChessFigureType.Knight);
                Player2.Figures.Add(ChessFigureType.Bishop);
            }

            Player1.Figures.Add(ChessFigureType.Queen);
            Player1.Figures.Add(ChessFigureType.King);

            Player2.Figures.Add(ChessFigureType.Queen);
            Player2.Figures.Add(ChessFigureType.King);
        }

        private void OkCommandHandler(IWindow window)
        {
            window.DialogResult = true;
        }

        private bool CanOkCommandHandler()
        {
            return Player1.Figures.Any() &&
                Player2.Figures.Any();
        }
    }
}