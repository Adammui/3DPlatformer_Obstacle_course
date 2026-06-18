using Gameplay;
using Gameplay.Platforms;
using Gameplay.Platforms.Hints;
using Gameplay.Player;
using UI;
using UnityEngine;
using Zenject;

namespace Installers
{
    public class LevelInstaller : MonoInstaller
    {
        private MainConfig _config;
        private PlayerStats _playerStats;
        [SerializeField] private LevelUI _levelUI;
        [SerializeField] private PlayerController _playerController;
        
        [Inject]
        private void Construct(MainConfig config,PlayerStats playerStats)
        {
            _playerStats = playerStats;
            _config = config;
        }

        public override void InstallBindings()
        {
            Container.Bind<LevelService>().FromNew().AsSingle().NonLazy();
            Container.Bind<PlatformsService>().FromNew().AsSingle().NonLazy();
            
            Container.Bind<PlatformPulseController>().AsSingle().NonLazy();
            Container.Bind<PlatformWindController>().AsSingle().NonLazy();
            
            Container.Bind<LevelConfig>().FromInstance(_config.LevelConfigs[_playerStats.CurrentLevel]).AsSingle();
            Container.Bind<LevelExitPoint>().FromNew().AsSingle().NonLazy();
            Container.Bind<IExitPoint>().To<LevelExitPoint>().FromResolve();
            Container.Bind<ContextLifetime>().FromNew().AsSingle().NonLazy();
            Container.Bind<LevelScreenPresenter>().AsSingle().NonLazy();
            Container.Bind<LevelUI>().FromInstance(_levelUI).AsSingle().NonLazy();
            Container.Bind<UIService>().To<LevelUI>().FromResolve();
            Container.Bind<PlayerController>().To<PlayerController>().FromInstance(_playerController).AsSingle().NonLazy();
            Container.Bind<PlayerDeathController>().FromNew().AsSingle().NonLazy();
            Container.Bind<LevelStateController>().FromNew().AsSingle().NonLazy();
            Container.Bind<EndScreenPresenter>().FromNew().AsSingle().NonLazy();
        }
    }
}