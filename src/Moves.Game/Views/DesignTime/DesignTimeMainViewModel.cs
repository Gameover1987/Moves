using Moves.Engine;
using Moves.Game.ViewModels;
using Moves.Game.ViewModels.Board;
using Moves.Game.ViewModels.Commands;

namespace Moves.Game.Views.DesignTime
{
    internal sealed class DesignTimeMainViewModel : IMovesViewModel
    {
        public DesignTimeMainViewModel()
        {
            Player1 = new DesignTimePlayerViewModel { Nick = "White", Color = FigureColor.White };
            Player2 = new DesignTimePlayerViewModel { Nick = "Black", Color = FigureColor.Black };
            Board = new DesignTimeBoardViewModel();
        }

        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public IBoardViewModel Board { get; private set; }

        public IPlayerViewModel ActivePlayer { get; }

        public INotifyCommand NewGameCommand { get; private set; }

        public string GameInfo
        {
            get { return "Инфа об игре"; }
        }

        public void DoMove(Position position)
        {
            throw new System.NotImplementedException();
        }
    }
}
