using System;
using System.Collections.ObjectModel;
using Moves.Engine;

namespace Moves.Game.ViewModels
{
    public class FigureSelectedEventArgs : EventArgs
    {
        public FigureType? Figure { get; }

        public FigureSelectedEventArgs(FigureType? figure)
        {
            Figure = figure;
        }
    }

    public interface IPlayerViewModel
    {
        string Nick { get; set; }

        FigureColor Color { get; set; }

        bool IsActive { get; set; }

        ObservableCollection<FigureType> Figures { get; }

        event EventHandler<FigureSelectedEventArgs> FigureSelected;

        FigureType? SelectedFigure { get; set; }
    }
}