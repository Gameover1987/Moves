using System;
using Moves.Engine.Figures;
using System.Collections.ObjectModel;

namespace Moves.Game.ViewModels
{
    public sealed class PlayerViewModel : ViewModelBase, IPlayerViewModel
    {
        private string _nick;

        private ChessFigureType? _selectedFigure;

        public PlayerViewModel()
        {
            Figures = new ObservableCollection<ChessFigureType>();
        }

        public FigureColor Color { get; set; }

        public ObservableCollection<ChessFigureType> Figures { get; private set; }

        public event EventHandler<FigureSelectedEventArgs> FigureSelected;

        public ChessFigureType? SelectedFigure
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