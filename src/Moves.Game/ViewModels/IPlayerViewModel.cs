using System;
using Moves.Engine.Figures;
using System.Collections.ObjectModel;

namespace Moves.Game.ViewModels
{
    public class FigureSelectedEventArgs : EventArgs
    {
        public ChessFigureType? Figure { get; }

        public FigureSelectedEventArgs(ChessFigureType? figure)
        {
            Figure = figure;
        }
    }

    public interface IPlayerViewModel
    {
        string Nick { get; set; }

        FigureColor Color { get; set; }

        ObservableCollection<ChessFigureType> Figures { get; }

        event EventHandler<FigureSelectedEventArgs> FigureSelected;

        ChessFigureType? SelectedFigure { get; set; }
    }
}