using Moves.Engine.Figures;

namespace Moves.Game.ViewModels.Board
{
    public class ChessBoardCellViewModel : ViewModelBase, IChessBoardCellViewModel
    {
        private readonly int _row;
        private readonly int _column;
        private readonly FigureColor _color;

        private IFigureViewModel _figure;

        public ChessBoardCellViewModel(int row, int column, FigureColor color)
        {
            _row = row;
            _column = column;
            _color = color;
        }

        public int Row => _row;

        public  int Column => _column;

        public FigureColor Color => _color;

        public IFigureViewModel Figure
        {
            get { return _figure;}
            set { SetProperty(() => _figure, value); } }
    }
}