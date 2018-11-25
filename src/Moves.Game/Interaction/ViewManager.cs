using Moves.Game.ViewModels;
using System.Windows;
using NewGameWindow = Moves.Game.Views.Windows.NewGameWindow;

namespace Moves.Game.Interaction
{

    public sealed class ViewManager : IViewManager
    {
        private readonly INewGameViewModel _newGameViewModel;

        public ViewManager(INewGameViewModel newGameViewModel)
        {
            _newGameViewModel = newGameViewModel;
        }

        public INewGameViewModel NewGame()
        {
            _newGameViewModel.Initialize();
            var newGameWindow = new NewGameWindow();
            newGameWindow.DataContext = _newGameViewModel;
            newGameWindow.Owner = Application.Current.MainWindow;

            if (newGameWindow.ShowDialog() == true)
            {
                return (INewGameViewModel)newGameWindow.DataContext;
            }

            return null;
        }
    }
}
