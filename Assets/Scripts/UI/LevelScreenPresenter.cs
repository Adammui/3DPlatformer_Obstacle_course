using System;
using Gameplay;
using Gameplay.Player;

namespace UI
{
   public class LevelScreenPresenter
    {
        private readonly PlayerStats _playerStats;
        private readonly LevelUI _levelUI;
        private LevelScreen _screen;
        
        private LevelScreenPresenter(PlayerStats playerStats, LevelUI levelUI)
        {
            _levelUI = levelUI;
            _playerStats = playerStats;
        }
        public void ShowScreen()
        {
            _screen = _levelUI.ShowScreen<LevelScreen>();
            _playerStats.HealthChanged += _screen.Health.SetHealth;
            _screen.Health.SetHealth(_playerStats.HealthCurrent);
        }
        public void CloseScreen()
        {
           if (_screen ==null)
               return;
           _playerStats.HealthChanged -= _screen.Health.SetHealth;
           _screen = null;
           _levelUI.HideScreen<LevelScreen>();
        }

        public void DisplayTime(float time)
        {
            if (_screen == null)
                return;
            _screen.UpdateIngameTimeDisplay(time);
        }
    }
}