using System.Collections.Generic;
using UnityEngine;

namespace UI.Elements
{
    public class HealthElement : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _hearts;

        public void SetHealth(int health)
        {
            for (int i = 0; i < _hearts.Count; i++)
            {
                _hearts[i].SetActive(i<health);
            }
        }
    }
}