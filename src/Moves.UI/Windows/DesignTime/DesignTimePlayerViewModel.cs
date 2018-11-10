using Moves.UI.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace Moves.UI.Windows.DesignTime
{
    internal sealed class DesignTimePlayerViewModel : IPlayerViewModel
    {
        public string Nick { get; set; }

        public ObservableCollection<IFigureViewModel> Figures => throw new NotImplementedException();
    }
}
