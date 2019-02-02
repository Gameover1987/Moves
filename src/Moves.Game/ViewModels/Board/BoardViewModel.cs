using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Moves.Engine.Board;
using Moves.Engine.Figures;

namespace Moves.Game.ViewModels.Board
{
    public sealed class BoardViewModel : ViewModelBase, IBoardViewModel
    {
        private readonly IBoard _board;
        private readonly IChessBoardCellViewModel[] _cells;

        private ChessFigureType? _addingFigure;

        public BoardViewModel(IBoard board, IChessBoardCellFactory cellFactory)
        {
            _board = board;
            var cells = new List<IChessBoardCellViewModel>();
            for (int i = GlobalConstants.DefaultWidth; i > 0; i--)
            {
                for (int j = 1; j <= GlobalConstants.DefaultHeight; j++)
                {
                    var cell = cellFactory.CreateCell(i, j);
                    cells.Add(cell);
                }
            }

            _cells = cells.ToArray();

            var firstRow = cells.Where(x => x.Row == 1).ToArray();
            firstRow[0].Figure = new Rook(new Position("A1").ToString()){ Color = FigureColor.White};
            firstRow[1].Figure = new Knight(new Position("B1").ToString()) { Color = FigureColor.White };
            firstRow[2].Figure = new Bishop(new Position("C1").ToString()) { Color = FigureColor.White };
            firstRow[3].Figure = new Queen(new Position("D1").ToString()) { Color = FigureColor.White };
            firstRow[4].Figure = new King(new Position("E1").ToString()) { Color = FigureColor.White };
            firstRow[5].Figure = new Bishop(new Position("F1").ToString()) { Color = FigureColor.White };
            firstRow[6].Figure = new Knight(new Position("G1").ToString()) { Color = FigureColor.White };
            firstRow[7].Figure = new Rook(new Position("H1").ToString()) { Color = FigureColor.White };

            var secondRow = cells.Where(x => x.Row == 2).ToArray();
            foreach (var cell in secondRow)
            {
                var position = new Position(cell.Column, cell.Row).ToString();
                cell.Figure = new Pawn(position) { Color = FigureColor.White};
            }

            var seventhRow = cells.Where(x => x.Row == 7).ToArray();
            foreach (var cell in seventhRow)
            {
                var position = new Position(cell.Column, cell.Row).ToString();
                cell.Figure = new Pawn(position){Color = FigureColor.Black};
            }

            var eightRow = cells.Where(x => x.Row == 8).ToArray();
            eightRow[0].Figure = new Rook(new Position("A8").ToString()) { Color = FigureColor.Black };
            eightRow[1].Figure = new Knight(new Position("B8").ToString()) { Color = FigureColor.Black };
            eightRow[2].Figure = new Bishop(new Position("C8").ToString()) { Color = FigureColor.Black };
            eightRow[3].Figure = new Queen(new Position("D8").ToString()) { Color = FigureColor.Black };
            eightRow[4].Figure = new King(new Position("E8").ToString()) { Color = FigureColor.Black };
            eightRow[5].Figure = new Bishop(new Position("F8").ToString()) { Color = FigureColor.Black };
            eightRow[6].Figure = new Knight(new Position("G8").ToString()) { Color = FigureColor.Black };
            eightRow[7].Figure = new Rook(new Position("H8").ToString()) { Color = FigureColor.Black };
        }

        public IChessBoardCellViewModel[] Cells => _cells;

        public ChessFigureType? AddingFigure
        {
            get => _addingFigure;
            set
            {
                if (_addingFigure == value)
                    return;
                _addingFigure = value;
                OnPropertyChanged(() => AddingFigure);
            }
        }

        public void PerformHitTest(string positionStr)
        {
            if (AddingFigure == null)
                return;

            var addingFigure = (ChessFigureType) AddingFigure;
            var figure = addingFigure.CreateFirgure(positionStr);

            var hitTest = _board.HitTest(figure);
        }
    }
}