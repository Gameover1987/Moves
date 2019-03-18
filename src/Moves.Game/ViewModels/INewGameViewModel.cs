using Moves.Game.ViewModels.Commands;
using System.Collections.ObjectModel;
using Moves.Engine;

namespace Moves.Game.ViewModels
{
    public interface INewGameViewModel
    {
        IPlayerViewModel Player1 { get; }
        IPlayerViewModel Player2 { get; }

        ObservableCollection<FigureType> Figures { get; }
        FigureType SelectedFigure { get; set; }

        INotifyCommand GiveFigureToPlayer1Command { get; }
        INotifyCommand GiveFigureToPlayer2Command { get; }
        INotifyCommand GiveDefaultFigureSetCommand { get; }
        INotifyCommand OkCommand { get; }

        void Initialize();
    }
}