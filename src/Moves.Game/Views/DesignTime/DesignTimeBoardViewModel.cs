using System.Collections.Generic;
using Moves.Engine.Board;
using Moves.Game.ViewModels.Board;

namespace Moves.Game.Views.DesignTime
{
    public class DesignTimeBoardViewModel : IBoardViewModel
    {
        private readonly IChessBoardCellViewModel[] _cells;

        public DesignTimeBoardViewModel()
        {
            var cells = new List<IChessBoardCellViewModel>();
            var factory = new ChessBoardCellFactory();
            for (int i = 0; i < GlobalConstants.DefaultWidth; i++)
            {
                for (int j = 0; j < GlobalConstants.DefaultHeight; j++)
                {
                    var cell = factory.CreateCell(i, j);
                    cells.Add(cell);
                }
            }

            _cells = cells.ToArray();
        }

        public IChessBoardCellViewModel[] Cells => _cells;
    }
}
