﻿using System;
using System.Collections.ObjectModel;
using Moves.Engine.Figures;
using Moves.Game.ViewModels;

namespace Moves.Game.Views.DesignTime
{
    internal sealed class DesignTimePlayerViewModel : IPlayerViewModel
    {
        public DesignTimePlayerViewModel()
        {
            Figures = new ObservableCollection<ChessFigureType>();
        }

        public string Nick { get; set; }
        public FigureColor Color { get; set; }

        public ObservableCollection<ChessFigureType> Figures { get; private set; }
        public event EventHandler<FigureSelectedEventArgs> FigureSelected;
        public ChessFigureType? SelectedFigure { get; set; }
    }
}
