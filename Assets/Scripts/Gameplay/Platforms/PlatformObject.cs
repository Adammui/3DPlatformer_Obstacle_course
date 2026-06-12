using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Platforms
{
    public class PlatformObject : MonoBehaviour
    {
        [SerializeReference, SubclassSelector] public IPlatform Platform;
        //public IPlatform Platform => platform;

        public event Action<List<CharacterController>> OnPlayersListChanged;

        public event Action<PlatformObject, int> OnPlatformInteracted;

        public List<CharacterController> charactersOnPlatformList = new List<CharacterController>();

        private void OnTriggerEnter(Collider target)
        {
            CharacterController
                characterController =
                    target.gameObject
                        .GetComponent<CharacterController>(); ///попробовать заменить это на health controller
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