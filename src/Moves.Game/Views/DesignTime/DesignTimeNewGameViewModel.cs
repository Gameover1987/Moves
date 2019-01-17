using System.Collections.ObjectModel;
using System.Linq;
using Moves.Engine.Figures;
using Moves.Game.ViewModels;
using Moves.Game.ViewModels.Commands;

namespace Moves.Game.Views.DesignTime
{
    internal sealed class DesignTimeNewGameViewModel : INewGameViewModel
    {
        public DesignTimeNewGameViewModel()
        {
            Player1 = new DesignTimePlayerViewModel { Nick = "Вячеслав" };
            Player2 = new DesignTimePlayerViewModel { Nick = "Петр" };

            for (var i = 0; i < 8; i++)
            {
                Player1.Figures.Add(ChessFigureType.Pawn);
                Player2.Figures.Add(ChessFigureType.Pawn);
            }


            Player1.Figures.Add(ChessFigureType.Rook);
            Player1.Figures.Add(ChessFigureType.Rook);
            Player1.Figures.Add(ChessFigureType.Knight);
            Player1.Figures.Add(ChessFigureType.Knight);
            Player1.Figures.Add(ChessFigureType.Bishop);
            Player1.Figures.Add(ChessFigureType.Bishop);
            Player1.Figures.Add(ChessFigureType.Queen);
            Player1.Figures.Add(ChessFigureType.King);

            Player2.Figures.Add(ChessFigureType.Rook);
            Player2.Figures.Add(ChessFigureType.Rook);
            Player2.Figures.Add(ChessFigureType.Knight);
            Player2.Figures.Add(ChessFigureType.Knight);
            Player2.Figures.Add(ChessFigureType.Bishop);
            Player2.Figures.Add(ChessFigureType.Bishop);
            Player2.Figures.Add(ChessFigureType.Queen);
            Player2.Figures.Add(ChessFigureType.King);
            

            Figures = new ObservableCollection<ChessFigureType>
            {
                ChessFigureType.Pawn,
                ChessFigureType.Rook,
                ChessFigureType.Knight,
                ChessFigureType.Bishop,
                ChessFigureType.Queen,
                ChessFigureType.King,
            };

            SelectedFigure = Figures.Last();
        }

        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public ObservableCollection<ChessFigureType> Figures { get; private set; }

        public ChessFigureType SelectedFigure { get; set; }

        public INotifyCommand GiveFigureToPlayer1Command { get; private set; }

        public INotifyCommand GiveFigureToPlayer2Command { get; private set; }

        public INotifyCommand GiveDefaultFigureSetCommand { get; private set; }

        public INotifyCommand OkCommand { get; private set; }
        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
