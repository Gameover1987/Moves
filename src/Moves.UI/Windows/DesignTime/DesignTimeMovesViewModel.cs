using Moves.UI.ViewModels;
using Moves.UI.ViewModels.Commands;

namespace Moves.UI.Windows.DesignTime
{
    internal sealed class DesignTimeMovesViewModel : IMovesViewModel
    {
        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public IBoardViewModel Board { get; private set; }

        public INotifyCommand NewGameCommand { get; private set; }
    }
}
