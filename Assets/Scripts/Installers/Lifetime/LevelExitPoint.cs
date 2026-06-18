using Gameplay.Platforms;
using Gameplay.Player;
using UI;
using UnityEngine;

namespace Installers
{
    public class LevelExitPoint : IExitPoint
    {
        private PlatformsService _platformsService;
        private readonly ContextLifetime _contextLifetime;
        private readonly LevelScreenPresenter _levelScreenPresenter;
        private LevelStateController _levelState;
        private readonly PlayerDeathController _deathController;


        public LevelExitPoint(PlatformsService platformsService,LevelStateController levelState, PlayerDeathController deathController, ContextLifetime contextLifetime,LevelScreenPresenter  levelScreenPresenter, EndScreenPresenter  endScreenPresenter)
        {
            _levelState = levelState;
            _deathController = deathController;
            _platformsService = platformsService;
            _contextLifetime = contextLifetime;
            _levelScreenPresenter = levelScreenPresenter;
            endScreenPresenter.SetExitPoint(this);
        }
        public void Exit()
        {
            _deathController.Dispose();
            Debug.Log("Exit check");
            _levelState.Dispose();
            _levelScreenPresenter.CloseScreen();
            _contextLifetime.Dispose();
            _platformsService.Dispose();
        }
    }
}