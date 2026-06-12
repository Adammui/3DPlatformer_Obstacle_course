using System;
using System.Collections.Generic;
using Gameplay.Platforms;
using Unity.VisualScripting;
using UnityEngine;

namespace Gameplay
{
    public class LevelStarter : MonoBehaviour
    {
        [SerializeField] public List<PlatformObject> platforms;
        [SerializeField] PlatformsService service;
        private Dictionary<PlatformObject, IPlatform> _platforms = new();
        private bool created = false;

        private void Update()
        {
            float dt = Time.deltaTime;
            foreach ( PlatformObject platform in platforms)
            {
                platform.Platform.Update(dt);
            }
                   
            if (!created)
            {
                created = true;
                service.Create(platforms);
            }
        }
    }
}
