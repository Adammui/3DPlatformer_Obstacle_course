using Gameplay.Platforms;
using UnityEngine;

namespace Gameplay
{
    public class LevelService
    {
        private readonly MainConfig _mainConfig;
        private readonly LevelConfig _levelConfig;
        
        public LevelService(MainConfig mainConfig, LevelConfig levelConfig)
        {
            _mainConfig = mainConfig;
            _levelConfig = levelConfig;
        }
        public Level SpawnLevel()
        {
            return GameObject.Instantiate(_levelConfig.Prefab);
        }
    }
}