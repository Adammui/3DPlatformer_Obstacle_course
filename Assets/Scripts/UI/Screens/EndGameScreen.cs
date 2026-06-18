using System;
using Gameplay.Player;
using ModestTree.Util;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace UI
{
    public class EndGameScreen : Screen
    {
        [SerializeField] private Button _reloadButton;
        [SerializeField] private TMP_Text _finishText;
        public event Action ReloadClicked;
        
        protected override void OnShowing()
        {
            base.OnShowing();
            _reloadButton.onClick.AddListener(OnReload);
        }

        public void UpdateText(string text)
        {
            _finishText.text = text;
        }

        private void OnReload()
        {
            ReloadClicked?.Invoke();
        }

        protected override void OnHiding()
        {
            base.OnHiding();
            
            _reloadButton.onClick.RemoveAllListeners();
        }
    }
}