using UnityEngine;
using UnityEngine.Serialization;

namespace UI
{
    public class StartUI : UIService
    {
        [SerializeField] private StartScreen _startScreen;
        public override void Initialize()
        {
            base.Initialize();
            
            _screens.Add(typeof(StartScreen), _startScreen);
            _startScreen.OnAwake();
        }
    }
}