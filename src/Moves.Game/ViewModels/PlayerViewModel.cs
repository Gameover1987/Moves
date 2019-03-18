using System;
using System.Collections.ObjectModel;
using Moves.Engine;

namespace Moves.Game.ViewModels
{
    public sealed class PlayerViewModel : ViewModelBase, IPlayerViewModel
    {
        private string _nick;

        private FigureType? _selectedFigure;

        public PlayerViewModel()
        {
            Figures = new ObservableCollection<FigureType>();
        }

        public FigureColor Color { get; set; }

        public ObservableCollection<FigureType> Figures { get; private set; }

        public event EventHandler<FigureSelectedEventArgs> FigureSelected;

        public FigureType? SelectedFigure
        {
            get { return _selectedFigure; }
            set
            {
                if (_selectedFigure == value)
                    return;
                _selectedFigure = value;
                OnPropertyChanged(() => SelectedFigure);

                if (SelectedFigure != null)
                    FigureSelected?.Invoke(this, new FigureSelectedEventArgs(SelectedFigure));
            }
        }

        public string Nick
        {
            get => _nick; set
            {
                SetProperty(() => _nick, value);
            }
        }
    }
}