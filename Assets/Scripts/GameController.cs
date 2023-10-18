using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private string _startPlatformName = "Start";
    private string _finishPlatformName = "Finish";

    public float _startTime;
    public bool _timerIsRunning = false;

    [SerializeField]
    private GameObject _defeatUI, _winUI;
    // Start is called before the first frame update
    private void Start()
    {
        _defeatUI = GameObject.Find("Defeat UI");
        _defeatUI.SetActive(false);
        _winUI = GameObject.Find("Win UI");
    }

    // Update is called once per frame
    void Update()
    {
        if (_timerIsRunning)
        {
            
            // show timer onscreen
            
        }
    }

    void OnTriggerExit(Collider collider)
    {
        Debug.Log(collider.tag);
        if (collider.tag == _startPlatformName)
        {
            HandleGameStart();
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag+ " entered finishline");
        if (collider.tag == _finishPlatformName)
        {
            HandleWin();
        }
    }
    public void HandleGameStart()
    {
         _timerIsRunning = true;
         _startTime = Time.time;
         //start timer and show timer onscreen
    }

    public void HandleWin() 
    {
        //Time.time - _startTime;
        _timerIsRunning = false;
        //finish game with win UI
        //stop time not to move
    }

    // Handles all the stuff when player looses all hp ( called from Health controller too)
    public void HandleDefeat()
    {
        _defeatUI.SetActive(true);
        Time.timeScale = 0;
        // animation

        // spawn system - reset game
        // game system counts time from start to finish and shows interface
        // - win and loose also counts number of deaths

    }
}
