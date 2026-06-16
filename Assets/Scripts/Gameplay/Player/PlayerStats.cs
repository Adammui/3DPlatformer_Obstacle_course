namespace Gameplay.Player
{
    public class PlayerStats
    {
        private int _currentLevel = 0;

        public int CurrentLevel => _currentLevel;

        public void SetLevel(int level)
        {
            _currentLevel = level;
            
        }
    }
}