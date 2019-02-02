using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moves.Engine.Figures;
using Moves.Game.ViewModels.Board;

namespace Moves.Game.Views.DesignTime
{
    public class DesignTimeChessBoardCellViewModel : ChessBoardCellViewModel
    {
        public DesignTimeChessBoardCellViewModel()
            : base(1, 1, FigureColor.Black)
        {
            Figure = new Pawn("A2");
        }
    }
}
