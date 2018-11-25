using System.Collections.Generic;
using Moves.Engine.Board;

namespace Moves.Game.ViewModels.Board
{
    public sealed class BoardViewModel : IBoardViewModel
    {
        private readonly IChessBoardCellViewModel[] _cells;

        public BoardViewModel(IChessBoardCellFactory cellFactory)
        {
            var cells = new List<IChessBoardCellViewModel>();
            for (int i = 0; i < GlobalConstants.DefaultWidth; i++)
            {
                for (int j = 0; j < GlobalConstants.DefaultHeight; j++)
                {
                    var cell = cellFactory.CreateCell(i, j);
                    cells.Add(cell);
                }
            }

            _cells = cells.ToArray();
        }

        public IChessBoardCellViewModel[] Cells
        {
            get { return _cells; }
        }
    }
}