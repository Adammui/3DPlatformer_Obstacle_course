using System;
using System.Collections.Generic;
using Gameplay;
using Gameplay.Platforms;
using UnityEngine;
using Zenject;

namespace Installers.EntryPoint
{
    public class LevelEntryPoint : EntryPoint
    {
        private LevelService _levelService;
        private PlatformsService _platformsService;
        [Inject]
        private void Construct(LevelService levelService, PlatformsService platformsService)
        {
            _levelService = levelService;
            _platformsService = platformsService;
        }

        private void Update()
        {
            _platformsService.Update();
        }

        protected override void Run()
        {
            var level = _levelService.SpawnLevel();
            _platformsService.InitializePlatforms(level.Platforms);
        }
    }
}