using Moves.Engine.Figures;
using Moves.Game.ViewModels.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Moves.Game.ViewModels
{
    public sealed class NewGameViewModel : ViewModelBase, INewGameViewModel
    {
        private readonly ObservableCollection<ChessFigureType> _figures;
        private ChessFigureType _selectedFigure;

        public NewGameViewModel(IPlayerViewModelFactory playerViewModelFactory)
        {
            Player1 = playerViewModelFactory.CreatePlayer();
            Player2 = playerViewModelFactory.CreatePlayer();

            _figures = new ObservableCollection<ChessFigureType>(Enum.GetValues(typeof(ChessFigureType)).Cast<ChessFigureType>());

            GiveFigureToPlayer1Command = new NotifyCommand(GiveFigureToPlayer1CommandHandler);
            GiveFigureToPlayer2Command = new NotifyCommand(GiveFigureToPlayer2CommandHandler);
            GiveDefaultFigureSetCommand = new NotifyCommand(GiveDefaultFigureSetCommandHandler);
            OkCommand = new NotifyCommand(() => { }, OkCommandHandler);
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
            for (var i = 0; i < 8; i++)
            {
                Player1.Figures.Add(ChessFigureType.Pawn);
                Player2.Figures.Add(ChessFigureType.Pawn);
            }


            Player1.Figures.Add(ChessFigureType.Rook);
            Player1.Figures.Add(ChessFigureType.Knight);
            Player1.Figures.Add(ChessFigureType.Bishop);
            Player1.Figures.Add(ChessFigureType.Queen);
            Player1.Figures.Add(ChessFigureType.King);

            Player2.Figures.Add(ChessFigureType.Rook);
            Player2.Figures.Add(ChessFigureType.Knight);
            Player2.Figures.Add(ChessFigureType.Bishop);
            Player2.Figures.Add(ChessFigureType.Queen);
            Player2.Figures.Add(ChessFigureType.King);
        }

        private bool OkCommandHandler()
        {
            return Player1.Figures.Any() &&
                Player2.Figures.Any();
        }
    }
}