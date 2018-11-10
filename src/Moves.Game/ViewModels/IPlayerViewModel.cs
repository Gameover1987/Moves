using Moves.Engine.Figures;
using System.Collections.ObjectModel;

namespace Moves.Game.ViewModels
{
    public interface IPlayerViewModel
    {
        string Nick { get; set; }

        ObservableCollection<ChessFigureType> Figures { get; }
    }
}