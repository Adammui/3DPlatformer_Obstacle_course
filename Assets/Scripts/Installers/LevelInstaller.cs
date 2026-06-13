using Gameplay;
using Zenject;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<LevelService>().FromNew().AsSingle().NonLazy();
        }
    }
}