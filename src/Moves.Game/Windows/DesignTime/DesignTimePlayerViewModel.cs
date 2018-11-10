using Moves.Engine.Figures;
using Moves.Game.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Moves.Game.Windows.DesignTime
{
    internal sealed class DesignTimePlayerViewModel : IPlayerViewModel
    {
        public DesignTimePlayerViewModel()
        {
            Figures = new ObservableCollection<ChessFigureType>();
        }

        public string Nick { get; set; }

        public ObservableCollection<ChessFigureType> Figures { get; private set; }
    }
}
