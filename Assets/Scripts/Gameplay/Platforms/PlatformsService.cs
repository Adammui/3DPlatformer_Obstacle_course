using System;
using System.Collections.Generic;
using System.Linq;
using Installers;
using Unity.VisualScripting;
using Unity.XR.Oculus.Input;
using UnityEngine;

namespace Gameplay.Platforms
{
    public class PlatformsService
    {
        private readonly MainConfig _mainConfig;
        private readonly ContextLifetime _contextLifetime;
        private readonly Dictionary<PlatformType, IPlatform> controllers = new();
        private List<PlatformObject> _platforms = new ();
        
        public PlatformsService(MainConfig mainConfig, ContextLifetime contextLifetime)
        {
            _mainConfig = mainConfig;
            _contextLifetime = contextLifetime;
            foreach (var type in Enum.GetValues(typeof(PlatformType)).Cast<PlatformType>())
            {
                controllers.Add(type, GetController(type));
            }
        }
        public void Update()
        {
            float dt = Time.deltaTime;
            foreach ( PlatformObject obj in _platforms)
            {
                controllers[obj.PlatformType].Update(obj,dt);
            }
        }
        public void InitializePlatforms(PlatformObject[] platforms)
        {
            _platforms.Clear();
            foreach (PlatformObject obj in platforms)
                if(obj !=null)
                    _platforms.Add(obj);
            
            foreach (PlatformObject obj in _platforms) // для каждого обьекта платформы на уровне
            {
                // foreach (PlatformType type in controllers.Keys)// для каждого типа платформ
                // {
                //     if (obj.PlatformType == type)
                //     {
                //         controllers[type].OnHintUpdate += obj.HintObj.UpdateHint; //для каждого типа платформ подписать только платформам этого типа
                //         if (controllers[type].Config.IsAlwaysActive) controllers[type].TurnOn(obj); //конфиг лежит в типе
                //     }
                // }
                if ( controllers[obj.PlatformType].Config.IsAlwaysActive) 
                    controllers[obj.PlatformType].TurnOn(obj); //конфиг лежит в типе
                
                obj.OnPlatformInteracted += OnPlatformInteraction;
            }
        }
        //todo exit point
        public void Dispose()
        {
            foreach (PlatformObject obj in _platforms)
            {
                if ( controllers[obj.PlatformType].Config.IsAlwaysActive)
                    controllers[obj.PlatformType].TurnOff(obj);
                
                obj.OnPlatformInteracted -= OnPlatformInteraction;
            }
            _platforms.Clear();
        }
        private void OnPlatformInteraction(PlatformObject obj, int players)
        {
            Debug.Log("player stepped in or out of platform");
            
            Action<PlatformObject> action = players>0 ? controllers[obj.PlatformType].TurnOn : controllers[obj.PlatformType].TurnOff;
            if (!controllers[obj.PlatformType].Config.IsAlwaysActive)
                action(obj);
        }
        private IPlatform GetController(PlatformType type)
        {
            return type switch
            {
                PlatformType.Wind => new PlatformWindController(_mainConfig,_contextLifetime),
                PlatformType.Pulse => new PlatformPulseController(_mainConfig,_contextLifetime),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}