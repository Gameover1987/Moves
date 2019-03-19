using System.Windows.Controls;
using System.Windows.Input;
using Moves.Engine;
using Moves.Game.ViewModels;

namespace Moves.Game.Views.Controls
{
    /// <summary>
    /// Interaction logic for PlayerControl.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public PlayerControl()
        {
            InitializeComponent();
        }

        private void EventSetter_OnHandler(object sender, MouseButtonEventArgs e)
        {
            var listBoxItem = sender as ListBoxItem;

            var playerViewModel = DataContext as IPlayerViewModel;
            playerViewModel.SelectedFigure = (FigureType)listBoxItem.DataContext;

        }
    }
}
