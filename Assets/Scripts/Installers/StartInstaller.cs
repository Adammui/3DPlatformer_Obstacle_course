using Zenject;

namespace Installers
{
    public class StartInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<StartExitPoint>().FromNew().AsSingle().NonLazy();
            Container.Bind<IExitPoint>().To<StartExitPoint>().FromResolve();
        }
    }
    public class StartExitPoint :IExitPoint
    {
        public void Exit() { }
    }
}