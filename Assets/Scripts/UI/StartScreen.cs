using System;
using Gameplay.Player;
using ModestTree.Util;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class StartScreen : Screen
    {
        [SerializeField] private Button _startNewGameButton;
        [SerializeField] private Button _quitGameButton;
        public event Action StartNewGameClicked;
        public event Action QuitGameClicked;
        
        protected override void OnShowing()
        {
            base.OnShowing();
            _startNewGameButton.onClick.AddListener(OnStartNewGame);
            _quitGameButton.onClick.AddListener(OnQuitGame);
        }

        private void OnQuitGame()
        {
            QuitGameClicked?.Invoke();
        }

        private void OnStartNewGame()
        {
            StartNewGameClicked?.Invoke();
        }

        protected override void OnHiding()
        {
            base.OnHiding();
            _startNewGameButton.onClick.RemoveAllListeners();
            _quitGameButton.onClick.RemoveAllListeners();
        }
    }
}