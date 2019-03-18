using Moves.Engine;

namespace Moves.Game.ViewModels.Board
{
    public class ChessBoardCellViewModel : ViewModelBase, IChessBoardCellViewModel
    {
        private readonly int _row;
        private readonly int _column;
        private readonly FigureColor _color;
        private CellState _state;

        private IFigure _figure;

        public ChessBoardCellViewModel(int row, int column, FigureColor color)
        {
            _row = row;
            _column = column;
            _color = color;
        }

        public int Row => _row;

        public int Column => _column;

        public FigureColor Color => _color;

        public IFigure Figure
        {
            get { return _figure; }
            set { SetProperty(() => _figure, value); }
        }

        public CellState State
        {
            get { return _state; }
            set
            {
                if (_state == value)
                    return;
                _state = value;
                OnPropertyChanged(() => State);
            }
        }

        public Position ToPosition()
        {
            return new Position(Column, Row);
        }

        public override string ToString()
        {
            if (Figure != null)
                return Figure.ToString();

            return new Position(Column, Row).ToString();
        }
    }
}