using System.Windows;
using Moves.Engine.Board;
using Moves.Game.Interaction;
using Moves.Game.ViewModels;
using Moves.Game.ViewModels.Board;
using Unity;
using MainWindow = Moves.Game.Views.Windows.MainWindow;

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
            _container.RegisterInstance<IBoard>(new Board(GlobalConstants.DefaultWidth, GlobalConstants.DefaultHeight));
            _container.RegisterSingleton<IBoardViewModel, BoardViewModel>();
            _container.RegisterSingleton<IViewManager, ViewManager>();
            _container.RegisterSingleton<INewGameViewModel, NewGameViewModel>();
            _container.RegisterSingleton<IPlayerViewModelFactory, PlayerViewModelFactory>();
            _container.RegisterSingleton<IChessBoardCellFactory, ChessBoardCellFactory>();
            _container.RegisterSingleton<IMovesViewModel, MovesViewModel>();
        }
    }
}
