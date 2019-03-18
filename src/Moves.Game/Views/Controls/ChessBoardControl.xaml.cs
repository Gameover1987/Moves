using System.Windows;
using System.Windows.Input;
using Moves.Engine;
using Moves.Game.ViewModels.Board;

namespace Moves.Game.Views.Controls
{
    /// <summary>
    /// Interaction logic for ChessBoardControl.xaml
    /// </summary>
    public partial class ChessBoardControl
    {
        private IBoardViewModel _boardViewModel;

        public ChessBoardControl()
        {
            InitializeComponent();
        }

        private void OnCellMouseEnter(object sender, MouseEventArgs e)
        {
            PerformHitTest(sender);
        }

        private void OnCellMouseMove(object sender, MouseEventArgs e)
        {
            PerformHitTest(sender);
        }

        private void OnCellMouseLeave(object sender, MouseEventArgs e)
        {
            PerformHitTest(sender);
        }

        private void ChessBoardControl_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _boardViewModel = e.NewValue as IBoardViewModel;
        }

        private void PerformHitTest(object sender)
        {
            var element = (FrameworkElement)sender;
            var cell = (IChessBoardCellViewModel)element.DataContext;
            if (cell.Figure != null)
            {
                cell.State = CellState.Red;
                return;
            }

            var position = new Position(cell.Column, cell.Row);
            var hitTest =_boardViewModel?.PerformHitTest(position.ToString());
            if (hitTest == null)
                return;

            if (hitTest.IsFree)
            {
                cell.State = CellState.Green;
            }
            else
            {
                cell.State = CellState.Red;
            }
        }

        private void OnCellMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_boardViewModel.AddingFigure == null)
                return;

            var element = (FrameworkElement)sender;
            var cell = (IChessBoardCellViewModel)element.DataContext;

            _boardViewModel.SetFigure(cell.ToPostion());
        }
    }
}
