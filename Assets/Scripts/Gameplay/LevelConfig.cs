using Gameplay.Platforms;
using Gameplay.Platforms.Hints;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(LevelConfig), fileName = nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private Level _prefab;
        public Level Prefab => _prefab;
        
    }
}