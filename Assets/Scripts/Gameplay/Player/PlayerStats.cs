using System;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerStats
    {
        private const int HealthInitial = 5;
        private int _healthCurrent = HealthInitial;
        public int HealthCurrent => _healthCurrent;
        private int _currentLevel = 0;
        public int CurrentLevel => _currentLevel;
        public event Action<int> HealthChanged;
        
        public void SetLevel(int level)
        {
            _currentLevel = level;
        }
        public void TakeDamage(int damageAmount)
        {
            _healthCurrent -= damageAmount;
            HealthChanged?.Invoke(_healthCurrent);
            Debug.Log("current players health: "+ HealthCurrent);
        }
        public void Heal(int healAmount)
        {
            _healthCurrent += healAmount;
            HealthChanged?.Invoke(_healthCurrent);
            Debug.Log("current players health: " + HealthCurrent);
        }
        public void ResetHealth()
        {
            _healthCurrent = HealthInitial;
            HealthChanged?.Invoke(_healthCurrent);
        }
    }
}