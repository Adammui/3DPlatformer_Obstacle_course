using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField]
    private Vector3 platformDirectionStart = new Vector3(1.0f, 0.0f, 0.0f);
    [SerializeField]
    private Vector3 platformDirectionChange = new Vector3(-1.0f, 0.0f, 0.0f);

    private Vector3 _platformDirection ;

    [SerializeField]
    private float platformSpeed =  5.0f;
    [SerializeField]
    private float platformSwing = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SwingCycle", 0, platformSwing);
        InvokeRepeating("BackSwing", platformSwing/2.0f, platformSwing);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_platformDirection * platformSpeed * Time.deltaTime);

        //transform.position += transform.forward * 6 * Time.deltaTime;
    }
    private void SwingCycle() {
        _platformDirection = platformDirectionStart;
    }

    // Provides cooldown for platform attack cycle
    private void BackSwing()
    {
        _platformDirection = platformDirectionChange;
    }
}
