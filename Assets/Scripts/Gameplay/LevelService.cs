using Gameplay.Platforms;
using UnityEngine;

namespace Gameplay
{
    public class LevelService
    {
        private readonly MainConfig _mainConfig;
        private readonly LevelConfig _levelConfig;
        private Level _levelObject;
        public Level LevelObject => _levelObject;

        public LevelService(MainConfig mainConfig, LevelConfig levelConfig)
        {
            _mainConfig = mainConfig;
            _levelConfig = levelConfig;
        }
        public Level SpawnLevel()
        {
            _levelObject = GameObject.Instantiate(_levelConfig.Prefab);
            return _levelObject;
        }
        public void Dispose()
        {
            GameObject.Destroy(_levelObject.gameObject);
        }
    }
}