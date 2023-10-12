using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPulseController : MonoBehaviour
{
    private float _pulseChargeTime = 1.0f;
    private float _pulseCooldownTime = 5.0f;
    private bool _isCycling = false;
    private bool _isTrackingPlayer = false;
    PlayerHealthController healthController = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);
        if (collider.tag == "Player")
        {
            _isTrackingPlayer = true;
            healthController = collider.GetComponent<PlayerHealthController>();
            if (!_isCycling) 
            { 
                // isCycling variable will be true until the end of the game
                // as stated in the task
                _isCycling = true; 
                NewPulseCycle();
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _isTrackingPlayer = false;
            healthController = null;
        }
    }

    void NewPulseCycle()
    {
        Debug.Log("new cycle");
        //change color to orng
        StartCoroutine(ChargeCoroutine());
    }

    private IEnumerator ChargeCoroutine()
    {
        Debug.Log("starting charge");
        yield return new WaitForSeconds(_pulseChargeTime);
        // change to red 
        if (_isTrackingPlayer)
        {
            // damage player for 1 health point
            healthController.TakeDamage(1);
            
            Debug.Log("deal damage");
            Debug.Log("current players health: " + healthController.healthCurrent);
        }
        StartCoroutine(CooldownCoroutine());

    }
    private IEnumerator CooldownCoroutine()
    {
            Debug.Log("waiting cooldown");
            yield return new WaitForSeconds(_pulseCooldownTime);
            NewPulseCycle();
    }
}