using System;
using System.Collections.Generic;
using Gameplay.Platforms.Hints;
using UnityEngine;

namespace Gameplay.Platforms
{
    [Serializable]
    public abstract class IPlatform
    {
        public abstract bool IsActive { get; set; }
        [SerializeField] public PlatformConfig Config;
        [SerializeField] public HintObject HintObj;
        public abstract void Update(float deltaTime);
        public abstract void OnPlayersAffectedChanged(List<CharacterController> playersAffected);
        public abstract void TurnOn();
        public abstract void TurnOff();
        public abstract event Action<HintUpdateContext> OnHintUpdate;
    }
}