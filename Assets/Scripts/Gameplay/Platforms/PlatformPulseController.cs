using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.Platforms.Hints;

namespace Gameplay.Platforms
{
    [Serializable]
    public class PlatformPulseController : IPlatform
    {
        [SerializeField] private float pulseChargeTime = 1.0f;
        [SerializeField] private float pulseCooldownTime = 5.0f;
        
        private List<CharacterController> playersAffectedByPlatform = new List<CharacterController>();
    
        public override event Action<HintUpdateContext> OnHintUpdate;
        public override bool IsActive { get; set; }
        public PlatformPulseController()
        {
            IsActive = false;
        }

        public override void Update(float deltaTime)
        {
        }

        public override void TurnOn()
        { 
            if (!IsActive) 
            { 
                IsActive = true; 
                HintObj.ShowHint();
                NewPulseCycle();
            }
        }

        public override void TurnOff()
        {
            // if (IsActive)
            // {
            //     await currentCycle;
        }
        private async UniTaskVoid NewPulseCycle()
        {
            Debug.Log("new cycle");
            OnHintUpdate?.Invoke(new HintUpdateContext(Vector3.zero,Config.PulseConfig.materialCharge));
            await StartPulseCycleAsync(CancellationToken.None);
        }
        public async UniTask StartPulseCycleAsync(CancellationToken token)
        { 
            Debug.Log("starting charge");
            await UniTask.Delay(TimeSpan.FromSeconds(pulseChargeTime), cancellationToken: token);
        
            // changing color of platform to red
            OnHintUpdate?.Invoke(new HintUpdateContext(Vector3.zero,Config.PulseConfig.materialDamage));
            if (playersAffectedByPlatform.Count > 0)
            {
                foreach (var player in playersAffectedByPlatform)
                {
                    // damage player for 1 health point
                    player.GetComponent<PlayerHealthController>()?.TakeDamage(1);

                    Debug.Log("deal damage");
                }
            }
            // waiting just a little for player to see red coloring
            await UniTask.Delay(TimeSpan.FromSeconds(0.1f), cancellationToken: token);
             // changing color back to basic state
            OnHintUpdate?.Invoke(new HintUpdateContext(Vector3.zero,Config.PulseConfig.materialInteractive));
            await UniTask.Delay(TimeSpan.FromSeconds(pulseCooldownTime), cancellationToken: token);
            if(playersAffectedByPlatform.Count > 0) NewPulseCycle();
            else 
            {
                IsActive = false;
                HintObj.StopHint();
            }
        }
        
        public override void OnPlayersAffectedChanged(List<CharacterController> playersAffected)
        {
            playersAffectedByPlatform = playersAffected;
        }
    }
}