using Moves.Engine.Figures;
using Moves.Game.ViewModels.Commands;
using System.Collections.ObjectModel;

namespace Moves.Game.ViewModels
{
    public interface INewGameViewModel
    {
        IPlayerViewModel Player1 { get; }
        IPlayerViewModel Player2 { get; }

        ObservableCollection<ChessFigureType> Figures { get; }
        ChessFigureType SelectedFigure { get; set; }

        INotifyCommand GiveFigureToPlayer1Command { get; }
        INotifyCommand GiveFigureToPlayer2Command { get; }
        INotifyCommand GiveDefaultFigureSetCommand { get; }
        INotifyCommand OkCommand { get; }
    }
}