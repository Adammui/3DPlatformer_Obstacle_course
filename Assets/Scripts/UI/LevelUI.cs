using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class LevelUI : UIService
    {
        [SerializeField] private LevelScreen _levelScreen;
        public LevelScreen LevelScreen => _levelScreen;
        public override void Initialize()
        {
            base.Initialize();
            
            _screens.Add(typeof(LevelScreen), _levelScreen);
            _levelScreen.OnAwake();
        }
    }
}