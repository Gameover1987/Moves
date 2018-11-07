using System.Collections.ObjectModel;

namespace Moves.UI.ViewModels
{
    public interface IPlayerViewModel
    {
        ObservableCollection<IFigureViewModel> Figures { get; }
    }

    public sealed class PlayerViewModel : IPlayerViewModel
    {
        public ObservableCollection<IFigureViewModel> Figures { get; }
    }
}