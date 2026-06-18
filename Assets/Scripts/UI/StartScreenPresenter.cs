using System;
using Gameplay;
using Gameplay.Player;
using Installers;
using UnityEngine;
using Zenject;

namespace UI
{
   public class StartScreenPresenter
    {
        private readonly UIService _uiService;
        private readonly SceneLoader _sceneLoader;
        private readonly IExitPoint _exitPoint;

        private StartScreenPresenter(UIService uiService,SceneLoader sceneLoader ,IExitPoint  exitPoint)
        {
            _uiService = uiService;
            _sceneLoader = sceneLoader;
            _exitPoint = exitPoint;
        }
        public void ShowScreen()
        {
            StartScreen screen = _uiService.ShowScreen<StartScreen>();
            screen.StartNewGameClicked += StartGame;
            screen.QuitGameClicked += QuitGame;
        }
        private void StartGame()
        { 
            _exitPoint.Exit();
            _sceneLoader.LoadLevel();
        }

        private void QuitGame()
        {
            _exitPoint.Exit();
            Application.Quit();
        }
    }
}