using System;
using Gameplay.Platforms.Hints;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Platforms
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(PlatformConfig), fileName = nameof(PlatformConfig))]
    [Serializable]
    public class PlatformConfig: ScriptableObject
    {
        public const string Name = "Platforms/";

        [SerializeField] private float damage;
        [SerializeField] private float cooldown;
        [SerializeField] private PrefabAssetType prefab;
        [SerializeField] private bool isAlwaysActive;
        [SerializeField] public HintPulseConfig PulseConfig;

        public float Damage => damage;
        public float Cooldown => cooldown;
        public PrefabAssetType Prefab => prefab;
        public bool IsAlwaysActive => isAlwaysActive;
        
       // public abstract IPlatform CreatePlatform(PlatformDependencies dependencies);
    }
}