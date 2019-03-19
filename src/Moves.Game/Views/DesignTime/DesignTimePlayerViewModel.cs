using System;
using System.Collections.ObjectModel;
using Moves.Engine;
using Moves.Game.ViewModels;

namespace Moves.Game.Views.DesignTime
{
    internal sealed class DesignTimePlayerViewModel : IPlayerViewModel
    {
        public DesignTimePlayerViewModel()
        {
            Figures = new ObservableCollection<FigureType>();
        }

        public string Nick { get; set; }
        public FigureColor Color { get; set; }
        public bool IsActive { get; set; }

        public ObservableCollection<FigureType> Figures { get; private set; }
        public event EventHandler<FigureSelectedEventArgs> FigureSelected;
        public FigureType? SelectedFigure { get; set; }
    }
}
