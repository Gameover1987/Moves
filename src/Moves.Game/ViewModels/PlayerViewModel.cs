using System;
using System.Collections.ObjectModel;
using Moves.Engine;

namespace Moves.Game.ViewModels
{
    public sealed class PlayerViewModel : ViewModelBase, IPlayerViewModel
    {
        private string _nick;
        private bool _isActive;

        private FigureType? _selectedFigure;

        public PlayerViewModel()
        {
            Figures = new ObservableCollection<FigureType>();
        }

        public FigureColor Color { get; set; }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive == value)
                    return;
                _isActive = value;
                OnPropertyChanged(() => IsActive);
            }
        }

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

                FigureSelected?.Invoke(this, new FigureSelectedEventArgs(SelectedFigure));
            }
        }

        public string Nick
        {
            get { return _nick; }
            set
            {
                if (_nick == value)
                    return;

                _nick = value;
                OnPropertyChanged(() => Nick);
            }
        }
    }
}