using System;
using System.Collections.Generic;
using Gameplay;
using Gameplay.Platforms;
using Gameplay.Player;
using UI;
using UnityEngine;
using Zenject;

namespace Installers.EntryPoint
{
    public class LevelEntryPoint : EntryPoint
    {
        private LevelService _levelService;
        private PlatformsService _platformsService;
        private LevelUI _ui;
        private LevelScreenPresenter _levelScreenPresenter;
        private PlayerController _player;
        private PlayerDeathController _deathController;
        private LevelStateController _levelState;
        private PlayerStats _stats;

        [Inject]
        private void Construct(LevelService levelService,PlayerStats stats, LevelStateController levelState, PlatformsService platformsService, LevelUI ui, LevelScreenPresenter levelScreenPresenter, PlayerController player, PlayerDeathController deathController )
        {
            _stats = stats;
            _levelState = levelState;
            _deathController = deathController;
            _player = player;
            _levelService = levelService;
            _platformsService = platformsService;
            _ui = ui;
            _levelScreenPresenter = levelScreenPresenter;
        }
        private void Update()
        {
            _player.OnUpdate();
            _platformsService.Update();
            _deathController.OnUpdate();
        }
        protected override void Run()
        {
            _stats.ResetHealth();
            _ui.Initialize();
            var level = _levelService.SpawnLevel();
            _platformsService.InitializePlatforms(level.Platforms);
            _levelScreenPresenter.ShowScreen();
            _levelState.Initialize();
            _deathController.Initialize();
        }
    }
}