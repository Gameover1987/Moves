using System.Collections.ObjectModel;

namespace Moves.UI.ViewModels
{
    public interface IPlayerViewModel
    {
        string Nick { get; set; }

        ObservableCollection<IFigureViewModel> Figures { get; }
    }

    public sealed class PlayerViewModel : IPlayerViewModel
    {
        public ObservableCollection<IFigureViewModel> Figures { get; }
        public string Nick { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}