using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartUIController : MonoBehaviour
{
    public string levelScene;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    public void CloseGame()
    {
        Application.Quit();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(levelScene, LoadSceneMode.Single);
    }
}
