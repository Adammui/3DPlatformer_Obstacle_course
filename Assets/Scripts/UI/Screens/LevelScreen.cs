using Gameplay.Player;
using TMPro;
using UI.Elements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace UI
{
    public class LevelScreen : Screen
    {
        [SerializeField] private HealthElement _health;
        [SerializeField] private TMP_Text _timeIngame;
        public HealthElement Health => _health;
        
        public void UpdateIngameTimeDisplay(float timeToDisplay, string caption="")
        {
            float minutes = Mathf.FloorToInt(timeToDisplay / 60);
            float seconds = Mathf.FloorToInt(timeToDisplay % 60);
            _timeIngame.text = caption + string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }
}