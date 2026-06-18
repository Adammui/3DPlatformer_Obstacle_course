using System;

namespace Gameplay.Player
{
    public class PlayerDeathController
    {
        private readonly PlayerController _playerController;
        private readonly PlayerStats _playerStats;
        private bool _isDead = false;
        public event Action PlayerDead;
        public PlayerDeathController(PlayerController playerController, PlayerStats playerStats)
        {
            _playerController = playerController;
            _playerStats = playerStats;
        }

        public void Initialize()
        {
            _isDead = false;
            _playerStats.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged(int health)
        {
            if(health ==0 && _isDead == false)
            {
                _isDead = true;
                PlayerDead?.Invoke();
                
            }
        }

        public void Dispose()
        {
            _isDead = false;
            _playerStats.HealthChanged -= OnHealthChanged;
        }
        public void OnUpdate()
        {
            if (!_playerController.IsGrounded() && _playerController.Velocity<-10.0f && !_isDead)
            {
                _isDead = true;
                PlayerDead?.Invoke();
                
            }
        }
    }
}