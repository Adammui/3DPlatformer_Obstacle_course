using System;
using UnityEngine;

namespace Gameplay.Platforms
{
    public class LevelStatePlatform:MonoBehaviour
    {
        public event Action StatePlatformEntered;

        // Called when trigger tracked collider leaving zone - start zone
        void OnTriggerEnter(Collider collider)
        {
            Debug.Log("player exited: " + collider.tag);
            if (collider.TryGetComponent<CharacterController>(out var controller))
            {
                StatePlatformEntered?.Invoke();
            }
        }
    }
}