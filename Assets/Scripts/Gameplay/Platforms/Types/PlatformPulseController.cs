using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.Platforms.Hints;
using Gameplay.Player;
using Installers;

namespace Gameplay.Platforms
{
    [Serializable]
    public class PlatformPulseController : IPlatform
    {
        private readonly ContextLifetime _contextLifetime;
        private readonly PlayerStats _playerStats;
        private readonly HintPulseConfig _hintConfig;
    
        private float pulseChargeTime = 1.0f;
        private float pulseCooldownTime = 2.0f;
        public PlatformPulseController(MainConfig mainConfig, ContextLifetime contextLifetime, PlayerStats playerStats)
        {
            _contextLifetime = contextLifetime;
            _playerStats = playerStats;
            Config = mainConfig.PulseConfig;
            _hintConfig = mainConfig.HintPulseConfig;
        }
        public override void Update(PlatformObject obj,float deltaTime) { }
        public override void TurnOn(PlatformObject obj)
        { 
            Debug.Log("platform turned on"+obj.gameObject.name);
            if (!obj.IsActive) 
            { 
                obj.IsActive = true; 
                obj.HintObj.ShowHint();
                StartPulse(obj).Forget();
            }
        }
        public override void TurnOff(PlatformObject obj) { 
            Debug.Log("platform turned off"+obj.gameObject.name);}
        private async UniTaskVoid StartPulse(PlatformObject obj)
        {
            Debug.Log("new cycle");
            obj.HintObj.UpdateHint(new HintUpdateContext(Vector3.zero,_hintConfig.materialCharge));
            await PulseCycleAsync(obj,_contextLifetime.Token);
        }
        public async UniTask PulseCycleAsync(PlatformObject obj, CancellationToken token)
        { 
            Debug.Log("starting charge"+obj.gameObject.name);
            await UniTask.Delay(TimeSpan.FromSeconds(pulseChargeTime), cancellationToken: token);
            
           obj.HintObj.UpdateHint(new HintUpdateContext(Vector3.zero,_hintConfig.materialDamage));
            if (obj.charactersOnPlatformList.Count > 0)
                foreach (var player in obj.charactersOnPlatformList)
                    _playerStats.TakeDamage(Config.Damage);
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token); // waiting just a little for player to see red coloring
            
            await EndPulseAsync(obj,token);
        }
        private async UniTask EndPulseAsync(PlatformObject obj, CancellationToken token)
        {
            Debug.Log("ending"+obj.gameObject.name);
            obj.HintObj.UpdateHint(new HintUpdateContext(Vector3.zero,_hintConfig.materialInteractive));
            await UniTask.Delay(TimeSpan.FromSeconds(pulseCooldownTime), cancellationToken: token); //cooldown
            if (obj.charactersOnPlatformList.Count > 0) 
                StartPulse(obj).Forget();
            else 
            {
                obj.IsActive = false;
                obj.HintObj.StopHint();
            }
        }
    }
}