using System;
using System.Collections.Generic;
using Gameplay.Platforms;
using UnityEngine;

namespace Gameplay
{
    [CreateAssetMenu(menuName = "Configs/" + nameof(LevelConfig), fileName = nameof(LevelConfig))]
    public class LevelConfig : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;
        public GameObject Prefab => _prefab;
    }
}