using UnityEngine.SceneManagement;

namespace Gameplay
{
    public class SceneLoader
    {
        public void LoadLevel()
        {
            SceneManager.LoadScene(1);
        }
        public void ReloadLevel()
        {
            LoadLevel();
        }
    }
}