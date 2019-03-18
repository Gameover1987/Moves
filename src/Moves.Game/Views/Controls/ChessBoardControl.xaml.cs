using System.Windows;
using System.Windows.Input;
using Moves.Engine;
using Moves.Game.ViewModels;
using Moves.Game.ViewModels.Board;

namespace Moves.Game.Views.Controls
{
    /// <summary>
    /// Interaction logic for ChessBoardControl.xaml
    /// </summary>
    public partial class ChessBoardControl
    {
        private IMovesViewModel _movesViewModel;

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
            _movesViewModel = e.NewValue as IMovesViewModel;
        }

        private void PerformHitTest(object sender)
        {
            var board = _movesViewModel.Board;
            var element = (FrameworkElement)sender;
            var cell = (IChessBoardCellViewModel)element.DataContext;
            if (cell.Figure != null)
            {
                cell.State = CellState.Red;
                return;
            }

            var position = new Position(cell.Column, cell.Row);
            var hitTest = board.PerformHitTest(position.ToString());
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
            var board = _movesViewModel.Board;
            if (board.AddingFigure == null)
                return;

            var element = (FrameworkElement)sender;
            var cell = (IChessBoardCellViewModel)element.DataContext;

            _movesViewModel.DoMove(cell.ToPosition());
        }
    }
}
