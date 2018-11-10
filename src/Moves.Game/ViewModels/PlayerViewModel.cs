using Moves.Engine.Figures;
using System.Collections.ObjectModel;

namespace Moves.Game.ViewModels
{
    public sealed class PlayerViewModel : ViewModelBase, IPlayerViewModel
    {
        private string _nick;

        public PlayerViewModel()
        {
            Figures = new ObservableCollection<ChessFigureType>();
        }

        public ObservableCollection<ChessFigureType> Figures { get; private set; }

        public string Nick
        {
            get => _nick; set
            {
                SetProperty(() => _nick, value);
            }
        }
    }
}