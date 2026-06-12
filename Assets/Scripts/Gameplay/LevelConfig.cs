using System;
using System.Collections.Generic;
using Gameplay.Platforms;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(LevelConfig), fileName = nameof(LevelConfig))]
    [Serializable]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] public Dictionary<PlatformType, PlatformConfig> LevelDictionary { get; set; } = new Dictionary<PlatformType, PlatformConfig>();
    }
}