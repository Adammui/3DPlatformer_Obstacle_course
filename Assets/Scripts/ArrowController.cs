using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    [SerializeField]
    private PlatformWindController platformWindController;
    
    void Update()
    {
       // Handling rotation of arrow on wind platform
        transform.forward = platformWindController.windDirection.normalized;
    }     
}
