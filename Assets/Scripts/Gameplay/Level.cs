using Gameplay.Platforms;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private PlatformObject[] platforms;
        [SerializeField] private LevelStatePlatform _startPlatform;
        [SerializeField] private LevelStatePlatform _finishPlatform;   
        public PlatformObject[] Platforms => platforms;
        public LevelStatePlatform StartPlatform => _startPlatform;
        public LevelStatePlatform FinishPlatform => _finishPlatform;
    }
}
