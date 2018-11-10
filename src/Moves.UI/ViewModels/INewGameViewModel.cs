using Moves.Engine.Tests;
using Moves.UI.ViewModels.Commands;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Moves.UI.ViewModels
{
    public interface INewGameViewModel
    {
        IPlayerViewModel Player1 { get; }
        IPlayerViewModel Player2 { get; }

        ObservableCollection<ChessFigureType> Figures { get; }

        INotifyCommand GiveFigureToPlayer1Command { get; }
        INotifyCommand GiveFigureToPlayer2Command { get; }
        INotifyCommand GiveDefaultFigureSetCommand { get; }
        INotifyCommand OkCommand { get; }
    }

    public sealed class NewGameViewModel : INewGameViewModel
    {
        public NewGameViewModel()
        {
            
        }

        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public ObservableCollection<ChessFigureType> Figures { get; private set; }

        public INotifyCommand GiveFigureToPlayer1Command { get; private set; }

        public INotifyCommand GiveFigureToPlayer2Command { get; private set; }

        public INotifyCommand GiveDefaultFigureSetCommand { get; private set; }

        public INotifyCommand OkCommand { get; private set; }
    }
}