using System;
using UnityEngine;

namespace Gameplay.Platforms.Hints
{
    [CreateAssetMenu(menuName = "Configs/Hints/Pulse", fileName = nameof(HintPulseConfig))]
    public class HintPulseConfig : ScriptableObject
    {
        [SerializeField] public Material materialCharge;
        [SerializeField] public Material materialDamage;
        [SerializeField] public Material materialInteractive;

    }
}