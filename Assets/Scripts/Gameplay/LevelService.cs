using UnityEngine;

namespace Gameplay
{
    public class LevelService
    {
        private readonly MainConfig _mainConfig;

        public LevelService(MainConfig mainConfig)
        {
            _mainConfig = mainConfig;
        }

        public void SpawnLevel()
        {
            GameObject.Instantiate(_mainConfig.LevelConfig.Prefab);
        }
    }
}