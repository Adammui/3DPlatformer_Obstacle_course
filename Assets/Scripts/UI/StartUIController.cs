using Gameplay;
using Installers;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StartUIController : MonoBehaviour
    {
        private SceneLoader _sceneLoader;
        private IExitPoint _exitPoint;

        [Inject]
        private void Construct(SceneLoader sceneLoader, IExitPoint  exitPoint)
        {
            _exitPoint = exitPoint;
            _sceneLoader = sceneLoader;
        }
        public void CloseGame()
        {
            Application.Quit();
        }
        public void LoadScene()
        {
            _sceneLoader.LoadLevel();
        }
        public void ReloadScene()
        {
            _exitPoint.Exit();
            _sceneLoader.ReloadLevel();
        }
    }
}
