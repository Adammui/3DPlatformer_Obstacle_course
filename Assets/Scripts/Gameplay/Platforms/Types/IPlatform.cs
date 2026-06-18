using System;
using System.Collections.Generic;
using Gameplay.Platforms.Hints;
using UnityEngine;

namespace Gameplay.Platforms
{
    [Serializable]
    public abstract class IPlatform
    {
        private PlatformConfig _config;
        public PlatformConfig Config { get; set; }
        
        public abstract void Update(PlatformObject obj, float deltaTime);
        public abstract void TurnOn(PlatformObject obj);
        public abstract void TurnOff(PlatformObject obj);
    }
}