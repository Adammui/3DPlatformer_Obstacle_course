using Gameplay.Platforms;
using Gameplay.Platforms.Hints;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(MainConfig), fileName = nameof(MainConfig))]
    public class MainConfig : ScriptableObject
    {
        [SerializeField] private LevelConfig[] _levelConfigs;
        public LevelConfig[] LevelConfigs => _levelConfigs;
        
        [SerializeField] private HintPulseConfig _hintPulseConfig;
        [SerializeField] private PlatformConfig _pulseConfig;
        [SerializeField] private PlatformConfig _windConfig;
        
        public HintPulseConfig HintPulseConfig => _hintPulseConfig;
        public PlatformConfig PulseConfig => _pulseConfig;
        public PlatformConfig WindСonfig => _windConfig;
    }
}