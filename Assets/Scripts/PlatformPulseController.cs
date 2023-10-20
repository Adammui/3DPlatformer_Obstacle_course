using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformPulseController : MonoBehaviour
{
    [SerializeField]
    private float pulseChargeTime = 1.0f;
    [SerializeField]
    private float pulseCooldownTime = 5.0f;

    private bool _isCycling = false;
    private bool _isTrackingPlayer = false;
    PlayerHealthController healthController = null;

    [SerializeField]
    public Material materialCharge;
    [SerializeField]
    public Material materialDamage;
    [SerializeField]
    public Material materialInteractive;

    // Is called when any collider enters trigger of platform
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);
        if (collider.tag == "Player")
        {
            _isTrackingPlayer = true;
            healthController = collider.GetComponent<PlayerHealthController>();
            
            // isCycling variable will be true until the end of try
            // as stated in the task
            if (!_isCycling) 
            { 
                _isCycling = true; 
                NewPulseCycle();
            }
        }
    }

    // Is called when collider exits platform
    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            _isTrackingPlayer = false;
            healthController = null;
        }
    }

    // Is called after evety pulse attack of platform
    void NewPulseCycle()
    {
        Debug.Log("new cycle");
        this.GetComponent<MeshRenderer>().material = materialCharge;
        StartCoroutine(ChargeCoroutine());
    }

    // Executes platform's attack
    private IEnumerator ChargeCoroutine()
    {
        Debug.Log("starting charge");
        yield return new WaitForSeconds(pulseChargeTime);

        // changing color of platform to red
        this.GetComponent<MeshRenderer>().material = materialDamage;
        if (_isTrackingPlayer)
        {
            // damage player for 1 health point
            healthController.TakeDamage(1);
            
            Debug.Log("deal damage");
            Debug.Log("current players health: " + healthController.healthCurrent);
        }
        // waiting just a little for player to see red coloring
        yield return new WaitForSeconds(0.1f);
        // changing color back to basic state
        this.GetComponent<MeshRenderer>().material = materialInteractive;
        StartCoroutine(CooldownCoroutine());
    }

    // Provides cooldown for platform attack cycle
    private IEnumerator CooldownCoroutine()
    {
        Debug.Log("waiting cooldown");
        yield return new WaitForSeconds(pulseCooldownTime);
        NewPulseCycle();
    }
}