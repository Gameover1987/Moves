using System.Windows;
using Moves.Game.Interaction;
using Moves.Game.ViewModels;
using Moves.Game.Windows;
using Unity;

namespace Moves.Game
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IUnityContainer _container = new UnityContainer();

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            FillContainer();

            var mainWindow = new MainWindow();
            mainWindow.DataContext = _container.Resolve<IMovesViewModel>();
            mainWindow.Show();
        }

        private void FillContainer()
        {
            _container.RegisterType<IPlayerViewModel, PlayerViewModel>();
            _container.RegisterSingleton<IBoardViewModel, BoardViewModel>();
            _container.RegisterSingleton<IViewManager, ViewManager>();
            _container.RegisterSingleton<INewGameViewModel, NewGameViewModel>();
            _container.RegisterSingleton<IPlayerViewModelFactory, PlayerViewModelFactory>();
            _container.RegisterSingleton<IMovesViewModel, MovesViewModel>();
        }
    }
}
