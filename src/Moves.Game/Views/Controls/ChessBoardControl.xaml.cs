using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Moves.Engine.Figures;
using Moves.Game.ViewModels.Board;

namespace Moves.Game.Views.Controls
{
    /// <summary>
    /// Interaction logic for ChessBoardControl.xaml
    /// </summary>
    public partial class ChessBoardControl : UserControl
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
            var position = new Position(cell.Column, cell.Row);
            _boardViewModel?.PerformHitTest(position.ToString());
        }
    }
}
