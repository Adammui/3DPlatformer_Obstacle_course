using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Installers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Platforms
{
    public class PlatformWindController : IPlatform
    {
        private readonly ContextLifetime _contextLifetime;
        private const float windStrength = 5;
        private const float changeWindTime = 2.0f;
        private Vector3[] _arrayOfVectors = new[] 
        { new Vector3(0.0f, -1f, -1.0f), new Vector3(0.0f,  -1f, 1.0f), 
            new Vector3(1.0f,  -1f, 0.0f), new Vector3(-1.0f,  -1f, -1.0f) };
        private Vector3 _windDirection;
        public PlatformWindController(MainConfig mainConfig, ContextLifetime contextLifetime)
        {
            _contextLifetime = contextLifetime;
            Config = mainConfig.WindСonfig;
        }
        public override void Update(PlatformObject obj,float deltaTime)
        {
            //or update hint here if its other platform
            if (obj.IsActive & obj.charactersOnPlatformList.Count!=0)
            {
                foreach (CharacterController u in obj.charactersOnPlatformList)
                {
                    Vector3 windVelocity = _windDirection * (windStrength * Time.deltaTime);
                    u.Move(windVelocity);
                }
            }
        }
        private async UniTask ChangeCycleAsync(PlatformObject obj, CancellationToken token)
        {
            while (obj.IsActive) 
            { 
                ChangeWindDirection(obj); 
                await UniTask.Delay(TimeSpan.FromSeconds(changeWindTime),cancellationToken:token); 
            }
        }
        public override void TurnOn(PlatformObject obj)
        {
            obj.IsActive = true;
            obj.HintObj.ShowHint();
            ChangeCycleAsync(obj,_contextLifetime.Token).Forget();
        }
        public override void TurnOff(PlatformObject obj)
        {
            obj.IsActive = false;
            obj.HintObj.StopHint();
        }
        private void ChangeWindDirection(PlatformObject obj)
        {
            int randomDir = Random.Range(0, _arrayOfVectors.Length);
            _windDirection = _arrayOfVectors[randomDir];
            //in wind platforms updating hints only needed when changing direction, not in update
            obj.HintObj.UpdateHint(new HintUpdateContext(_windDirection));
        }
    }
}
