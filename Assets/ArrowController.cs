using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private PlatformWindController platformWindController;
    
    // Handling rotation of arrow on wind platform
    void Update()
    {
        transform.forward = platformWindController.windDirection.normalized;
    }     
}
