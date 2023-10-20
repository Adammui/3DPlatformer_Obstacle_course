using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformDamageController : MonoBehaviour
{
    [SerializeField]
    private float atkCooldownTime = 1.0f;

    private bool _isTrackingPlayer = false;
    PlayerHealthController healthController = null;

    [SerializeField]
    public Material materialCharge;
    [SerializeField]
    public Material materialDamage;

    // Start is called before the first frame update
    void Start()
    {
        NewPulseCycle();
    }

    // Is called when any collider enters trigger of platform
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);
        if (collider.tag == "Player")
        {
            _isTrackingPlayer = true;
            healthController = collider.GetComponent<PlayerHealthController>();
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
        this.GetComponent<MeshRenderer>().material = materialCharge;
        StartCoroutine(AttackCoroutine());
    }

    // Executes platform's attack
    private IEnumerator AttackCoroutine()
    {
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
        this.GetComponent<MeshRenderer>().material = materialCharge;
        StartCoroutine(CooldownCoroutine());
    }

    // Provides cooldown for platform attack cycle
    private IEnumerator CooldownCoroutine()
    {
        yield return new WaitForSeconds(atkCooldownTime);
        NewPulseCycle();
    }
}