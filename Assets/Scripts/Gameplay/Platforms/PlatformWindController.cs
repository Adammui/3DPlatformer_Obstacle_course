using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Random = System.Random;

namespace Gameplay.Platforms
{
    [Serializable]
    public class PlatformWindController : IPlatform
    {
        [SerializeField] private readonly float windStrength = 5;
        [SerializeField] private readonly float changeWindTime = 2.0f;
        private readonly Vector3[] _arrayOfVectors = new[] 
        { new Vector3(0.0f, -1f, -1.0f), new Vector3(0.0f,  -1f, 1.0f), 
            new Vector3(1.0f,  -1f, 0.0f), new Vector3(-1.0f,  -1f, -1.0f) };
        private readonly Random _random = new Random();
        private Vector3 _windDirection;
        private List<CharacterController> playersAffectedByPlatform = new List<CharacterController>();
        
        public override event Action<HintUpdateContext> OnHintUpdate;
        public override bool IsActive { get; set; }
        
        public PlatformWindController()
        {
            IsActive = false;
        }

        //todo
        public override void Update(float deltaTime)
        {
            //or update hint here if its other platform
            if (IsActive & playersAffectedByPlatform.Count > 0)
            {
                foreach (CharacterController u in playersAffectedByPlatform)
                {
                    Vector3 windVelocity = _windDirection * windStrength * Time.deltaTime;
                    u.Move(_windDirection * windStrength * Time.deltaTime);
                }
            }
        }
        
        public override async void TurnOn()
        { 
            IsActive = true;
            HintObj.ShowHint();
            while (IsActive) 
            { 
                await Task.Delay(TimeSpan.FromSeconds(changeWindTime)); 
                ChangeWindDirection(); 
            }
        }
        public override void TurnOff()
        {
            IsActive = false;
            HintObj.StopHint();
        }
        private void ChangeWindDirection()
        {
            var randomDir = _random.Next(0, _arrayOfVectors.Length);
            _windDirection = _arrayOfVectors[randomDir];
            //in wind platforms updating hints only needed when changing direction, not in update
            OnHintUpdate?.Invoke(new HintUpdateContext(_windDirection));
        }
        
        public override void OnPlayersAffectedChanged(List<CharacterController> playersAffected)
        {
            playersAffectedByPlatform = playersAffected;
        }
    }
}
