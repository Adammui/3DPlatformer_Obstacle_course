using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Gameplay.Platforms.Hints;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Platforms
{
    public class PlatformObject : MonoBehaviour
    {
        [SerializeField] private PlatformType _platformType;
        public PlatformType PlatformType => _platformType;
        [SerializeField] private HintObject _hintObj;
        public HintObject HintObj => _hintObj;
        public bool IsActive { get; set; }
        public event Action<List<CharacterController>> OnPlayersListChanged;
        public event Action<PlatformObject, int> OnPlatformInteracted;

        public List<CharacterController> charactersOnPlatformList = new List<CharacterController>();

        private void OnTriggerEnter(Collider target)
        {
            CharacterController
                characterController =
                    target.gameObject
                        .GetComponent<CharacterController>();
            if (characterController != null)
            {
                charactersOnPlatformList.Add(characterController);
                OnPlayersListChanged?.Invoke(charactersOnPlatformList);
                OnPlatformInteracted?.Invoke(this, charactersOnPlatformList.Count);
            }
        }
    private void OnTriggerExit(Collider target)
        {
            CharacterController characterController = target.gameObject.GetComponent<CharacterController>();
            if (characterController != null)
            {
                charactersOnPlatformList.Remove(characterController);
                OnPlayersListChanged?.Invoke(charactersOnPlatformList);
                OnPlatformInteracted?.Invoke(this,charactersOnPlatformList.Count);
            }
        
        }
    }
}