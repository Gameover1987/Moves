using System;

namespace Moves.UI.Interaction
{
    public interface IViewManager
    {
        void ShowNewGameWindow();
    }

    public sealed class ViewManager : IViewManager
    {
        public void ShowNewGameWindow()
        {
            throw new NotImplementedException();
        }
    }
}
