using Gameplay;
using Gameplay.Platforms;
using UI;
using Zenject;

namespace Installers.EntryPoint
{
    public class StartEntryPoint : EntryPoint
    {
        private UIService _ui;
        private StartScreenPresenter _startScreenPresenter;

        [Inject]
        private void Construct(UIService ui, StartScreenPresenter startScreenPresenter )
        {
            _startScreenPresenter = startScreenPresenter;
            _ui = ui;
        }
        protected override void Run()
        {
            _ui.Initialize();
            _startScreenPresenter.ShowScreen();
        }
    }
}