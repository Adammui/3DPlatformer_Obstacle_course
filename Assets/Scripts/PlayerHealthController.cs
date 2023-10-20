using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PlayerHealthController : MonoBehaviour
{
    private GameController _gameController;

    [SerializeField]
    private int healthInitial = 3;
    public int healthCurrent;

    private void EraseHeart(string healthAfter)
    {
        GameObject heart = GameObject.Find(healthAfter);
        heart.SetActive(false);
    }

    private void DrawHeart(string healthDefore)
    {
        GameObject heart = GameObject.Find(healthDefore);
        heart.SetActive(true);
        // create holder and pic
        /*
        GameObject imgObject = new GameObject("a");
        RectTransform trans = imgObject.AddComponent<RectTransform>();
        trans.transform.SetParent(_canvas.transform); // setting parent
        trans.anchoredPosition = new Vector2(0f, 0f); // setting position, will be on center
        trans.sizeDelta = new Vector2(25, 25); // custom size
        
        Image image = imgObject.AddComponent<Image>();
        Sprite img1 = Resources.Load<Sprite>("heart-icon-14");
        image.GetComponent<Image>().sprite = img1;

        imgObject.transform.SetParent(_canvas.transform);
        */
    }

    // Is called automatically before the first frame update
    void Start()
    {
        _gameController = GetComponent<GameController>();
        ResetHealth();
    }

    // Sets player's current health back to its initial value
    public void ResetHealth()
    {
        Time.timeScale = 1;
        healthCurrent = healthInitial;
        DrawHeart("0");
        DrawHeart("1");
        DrawHeart("2");
    }

    // Reduces player's current health
    public void TakeDamage(int damageAmount)
    {
        healthCurrent -= damageAmount;
        EraseHeart(healthCurrent.ToString());

        if (healthCurrent <= 0)
        {
            _gameController.HandleDefeat();
        }
    }

    //Increases player's current health
    public void Heal(int healAmount)
    {
        DrawHeart(healthCurrent.ToString());
        healthCurrent += healAmount;
        if (healthCurrent > healthInitial)
        {
            ResetHealth();
        }
    }
}