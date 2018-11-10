using Moves.UI.ViewModels;
using Moves.UI.Windows;
using System;
using System.Windows;

namespace Moves.UI.Interaction
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
