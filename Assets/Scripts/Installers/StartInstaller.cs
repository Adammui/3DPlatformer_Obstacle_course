using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class StartInstaller : MonoInstaller
    {
        [SerializeField] private StartUI _startUI;
        public override void InstallBindings()
        {
            Container.Bind<StartExitPoint>().FromNew().AsSingle().NonLazy();
            Container.Bind<IExitPoint>().To<StartExitPoint>().FromResolve();
            Container.Bind<UIService>().To<StartUI>().FromInstance(_startUI).AsSingle();
            Container.Bind<StartScreenPresenter>().FromNew().AsSingle().NonLazy();
        }
    }
    public class StartExitPoint :IExitPoint
    {
        public void Exit() { }
    }
}