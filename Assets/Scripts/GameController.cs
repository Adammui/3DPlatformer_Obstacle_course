using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    private string _startPlatformName = "Start";
    private string _finishPlatformName = "Finish";

    public float _startTime, _finishTime;
    public bool _timerIsRunning = false;

    [SerializeField]
    private GameObject _endGameUI;

    [SerializeField]
    private TMP_Text _secEnd, _secIngame, _endgamestate;

    // Start is called before the first frame update
    private void Start()
    {
        InvokeRepeating("UpdateScreenTime", 0, 1.0f);
    }

    // Update is called once per second. Displays current time in game
    void UpdateScreenTime()
    {
        if (_timerIsRunning)
        {
            DisplayTimeInTMP(Time.time - _startTime, _secIngame);
        }
    }

    // Called when trigger tracked collider leaving zone - start zone
    void OnTriggerExit(Collider collider)
    {
        Debug.Log("player exited: "+collider.tag);
        if (collider.tag == _startPlatformName)
        {
            TimerStart();
        }
    }

    // Called when trigger tracked some collider 
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("player entered: " + collider.tag);
        if (collider.tag == _finishPlatformName)
        {
            Debug.Log(collider.tag+ " entered finishline");
            HandleWin();
        }
        //else if (collider.tag == _finishPlatformName)
    }

     // Starts timer and show timer onscreen
    public void TimerStart()
    {
        Debug.Log("Game started!");
        _timerIsRunning = true;
        _startTime = Time.time;
        
    }

    // Called when timer ends
    public void TimerEnd()
    {
        _secIngame.text = "";
        //Vector3 targetPosition = new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, 0);
        //GameObject.Find("time").transform.position = Vector3.Lerp(GameObject.Find("time").transform.position, targetPosition, 1.5f * 10);

        _timerIsRunning = false;
        _finishTime = Time.time - _startTime;
         Debug.Log("Voyage time: " + _finishTime);

        //stopping time to block player from moving
        Time.timeScale = 0;
    }

    // Handles all the stuff that happens when player wins
    public void HandleWin() 
    {
        TimerEnd();
        //display endgame UI
        _endGameUI.SetActive(true);
        _endgamestate.text = "You succeeded!!!";
        DisplayTimeInTMP(_finishTime, _secEnd, "your space voyage time: ");
    }

    // Handles all the stuff that happens when player looses (called player lost all hp too)
    public void HandleDefeat()
    { 
        // animation
        // animation of timer
        Time.timeScale = 0;
        TimerEnd();
        _endGameUI.SetActive(true);
        _endgamestate.text = "Defeat..";
        DisplayTimeInTMP(_finishTime, _secEnd, "you wandered to no avail for some time: ");
       
    }

    // Places formatted time in given placeholder - Text Mesh Pro
    void DisplayTimeInTMP(float timeToDisplay, TMP_Text placeToDisplay, string caption="")
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        placeToDisplay.text = caption + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
