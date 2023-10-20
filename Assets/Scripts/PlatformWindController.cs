using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformWindController : MonoBehaviour
{
    [SerializeField]
    List<CharacterController> CharactersInWindZoneList = new List<CharacterController>();
    [SerializeField]
    private Vector3 windDirection = Vector3.right;
    [SerializeField]
    private float windStrength = 5;

    // Is called when any collider enters trigger of platform
    private void OnTriggerEnter(Collider col)
    {
        CharacterController _characterController = col.gameObject.GetComponent<CharacterController>();
        if (_characterController != null)
            CharactersInWindZoneList.Add(_characterController);
    }

    // Is called when collider exits platform
    private void OnTriggerExit(Collider col)
    {
        CharacterController _characterController = col.gameObject.GetComponent<CharacterController>();
        if (_characterController != null)
            CharactersInWindZoneList.Remove(_characterController);
    }

    // Is called every fixed frame rate.
    private void FixedUpdate()
    {
        if (CharactersInWindZoneList.Count > 0)
        {
            foreach (CharacterController u in CharactersInWindZoneList)
            {
                u.Move(windDirection * windStrength * Time.deltaTime);
            }
        }
    }
}
