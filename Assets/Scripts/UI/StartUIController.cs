using Gameplay;
using UnityEngine;
using Zenject;

namespace UI
{
    public class StartUIController : MonoBehaviour
    {
        private SceneLoader _sceneLoader;
        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
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
            _sceneLoader.ReloadLevel();
        }
    }
}
