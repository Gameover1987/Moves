using System.Collections.ObjectModel;
using System.Linq;
using Moves.Engine;
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
                Player1.Figures.Add(FigureType.Pawn);
                Player2.Figures.Add(FigureType.Pawn);
            }


            Player1.Figures.Add(FigureType.Rook);
            Player1.Figures.Add(FigureType.Rook);
            Player1.Figures.Add(FigureType.Knight);
            Player1.Figures.Add(FigureType.Knight);
            Player1.Figures.Add(FigureType.Bishop);
            Player1.Figures.Add(FigureType.Bishop);
            Player1.Figures.Add(FigureType.Queen);
            Player1.Figures.Add(FigureType.King);

            Player2.Figures.Add(FigureType.Rook);
            Player2.Figures.Add(FigureType.Rook);
            Player2.Figures.Add(FigureType.Knight);
            Player2.Figures.Add(FigureType.Knight);
            Player2.Figures.Add(FigureType.Bishop);
            Player2.Figures.Add(FigureType.Bishop);
            Player2.Figures.Add(FigureType.Queen);
            Player2.Figures.Add(FigureType.King);
            

            Figures = new ObservableCollection<FigureType>
            {
                FigureType.Pawn,
                FigureType.Rook,
                FigureType.Knight,
                FigureType.Bishop,
                FigureType.Queen,
                FigureType.King,
            };

            SelectedFigure = Figures.Last();
        }

        public IPlayerViewModel Player1 { get; private set; }

        public IPlayerViewModel Player2 { get; private set; }

        public ObservableCollection<FigureType> Figures { get; private set; }

        public FigureType SelectedFigure { get; set; }

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
