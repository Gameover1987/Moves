﻿using System.Collections.Generic;
using System.Linq;
using Moves.Engine;

namespace Moves.Game.ViewModels.Board
{
    public sealed class BoardViewModel : ViewModelBase, IBoardViewModel
    {
        private readonly IBoard _board;
        private readonly IChessBoardCellViewModel[] _cells;

        private FigureType? _addingFigure;

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

            //SetFigures(cells);
        }

        public IChessBoardCellViewModel[] Cells => _cells;

        public FigureColor CurrentColor { get; set; }

        public FigureType? AddingFigure
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

        public BoardHitTestResult PerformHitTest(string positionStr)
        {
            if (AddingFigure == null)
                return null;

            var addingFigure = (FigureType) AddingFigure;
            var figure = addingFigure.CreateFigure(CurrentColor, positionStr);

            var hitTest = _board.HitTest(figure);
            return hitTest;
        }

        public void SetFigure(IFigure figure)
        {
            if (figure == null)
                return;
            
            var cell = Cells.Single(x => x.Column == figure.Position.Column && x.Row == figure.Position.Row);
            cell.Figure = figure;
            _board.AddFigure(figure);
        }

        public void Reset()
        {
            AddingFigure = null;
            CurrentColor = FigureColor.White;
            foreach (var cell in Cells)
            {
                cell.Figure = null;
                cell.State = CellState.Green;
            }
            _board.Clear();
        }

        private static void SetFigures(List<IChessBoardCellViewModel> cells)
        {
            var firstRow = cells.Where(x => x.Row == 1).ToArray();
            firstRow[0].Figure = new Figure(FigureType.Rook, FigureColor.White, new Position("a1").ToString());
            firstRow[1].Figure = new Figure(FigureType.Knight, FigureColor.White, new Position("b1").ToString());
            firstRow[2].Figure = new Figure(FigureType.Bishop, FigureColor.White, new Position("c1").ToString());
            firstRow[3].Figure = new Figure(FigureType.Queen, FigureColor.White, new Position("d1").ToString());
            firstRow[4].Figure = new Figure(FigureType.King, FigureColor.White, new Position("e1").ToString());
            firstRow[5].Figure = new Figure(FigureType.Bishop, FigureColor.White, new Position("f1").ToString());
            firstRow[6].Figure = new Figure(FigureType.Knight, FigureColor.White, new Position("g1").ToString());
            firstRow[7].Figure = new Figure(FigureType.Rook, FigureColor.White, new Position("h1").ToString());

            var secondRow = cells.Where(x => x.Row == 2).ToArray();
            foreach (var cell in secondRow)
            {
                var position = new Position(cell.Column, cell.Row).ToString();
                cell.Figure = new Figure(FigureType.Pawn, FigureColor.White, position);
            }

            var seventhRow = cells.Where(x => x.Row == 7).ToArray();
            foreach (var cell in seventhRow)
            {
                var position = new Position(cell.Column, cell.Row).ToString();
                cell.Figure = new Figure(FigureType.Pawn, FigureColor.Black, position);
            }

            var eightRow = cells.Where(x => x.Row == 8).ToArray();
            eightRow[0].Figure = new Figure(FigureType.Rook, FigureColor.Black, new Position("a8").ToString());
            eightRow[1].Figure = new Figure(FigureType.Knight, FigureColor.Black, new Position("b8").ToString());
            eightRow[2].Figure = new Figure(FigureType.Bishop, FigureColor.Black, new Position("c8").ToString());
            eightRow[3].Figure = new Figure(FigureType.Queen, FigureColor.Black, new Position("d8").ToString());
            eightRow[4].Figure = new Figure(FigureType.King, FigureColor.Black, new Position("e8").ToString());
            eightRow[5].Figure = new Figure(FigureType.Bishop, FigureColor.Black, new Position("f8").ToString());
            eightRow[6].Figure = new Figure(FigureType.Knight, FigureColor.Black, new Position("g8").ToString());
            eightRow[7].Figure = new Figure(FigureType.Rook, FigureColor.Black, new Position("h8").ToString());
        }
    }
}