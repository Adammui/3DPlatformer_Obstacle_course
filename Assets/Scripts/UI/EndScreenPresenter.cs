using System;
using Gameplay;
using Gameplay.Player;
using Installers;
using UnityEngine;
using Zenject;

namespace UI
{
   public class EndScreenPresenter
    {
        private readonly UIService _uiService;
        private readonly SceneLoader _sceneLoader;
        private IExitPoint _exitPoint;

        private EndScreenPresenter(UIService uiService,SceneLoader sceneLoader)
        {
            _uiService = uiService;
            _sceneLoader = sceneLoader;
        }
        public void ShowScreen(string text)
        {
            EndGameScreen screen = _uiService.ShowScreen<EndGameScreen>();
            screen.ReloadClicked += ReloadGame;
            screen.UpdateText(text);
        }
        public void SetExitPoint(IExitPoint exitPoint)
        {
            _exitPoint = exitPoint;
        }
        private void ReloadGame()
        {
            _exitPoint.Exit();
            _sceneLoader.ReloadLevel();
        }
    }
}