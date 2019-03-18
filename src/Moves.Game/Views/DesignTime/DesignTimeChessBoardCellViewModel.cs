using Moves.Engine;
using Moves.Game.ViewModels.Board;

namespace Moves.Game.Views.DesignTime
{
    public class DesignTimeChessBoardCellViewModel : ChessBoardCellViewModel
    {
        public DesignTimeChessBoardCellViewModel()
            : base(1, 1, FigureColor.Black)
        {
            Figure = new Figure(FigureType.Pawn, FigureColor.White, "A2");
        }
    }
}
