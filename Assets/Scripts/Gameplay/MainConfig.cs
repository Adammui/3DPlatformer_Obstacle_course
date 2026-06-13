using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(MainConfig), fileName = nameof(MainConfig))]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private LevelConfig _levelConfig;
        public LevelConfig LevelConfig => _levelConfig;
    }
}