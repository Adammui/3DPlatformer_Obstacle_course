using Gameplay;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        [SerializeField] private MainConfig _mainConfig;
        public override void InstallBindings()
        {
            Container.Bind<SceneLoader>().FromNew().AsSingle().NonLazy();
            Container.Bind<MainConfig>().FromInstance(_mainConfig).AsSingle().NonLazy();
        }
    }
}