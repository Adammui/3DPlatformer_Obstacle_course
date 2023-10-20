using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlatformWindController : MonoBehaviour
{
    [SerializeField]
    List<CharacterController> CharactersInWindZoneList = new List<CharacterController>();

    [SerializeField]
    private Vector3 _windDirection;

    private Vector3[] _arrayOfVectors = new[] { new Vector3(0.0f, 0.0f, -1.0f), new Vector3(0.0f, 0.0f, 1.0f), 
                                                new Vector3(1.0f, 0.0f, 0.0f), new Vector3(-1.0f, 0.0f, -1.0f) };

    [SerializeField]
    private float _windStrength = 5;

    [SerializeField]
    private float _changeWindTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        ChangeWindDirection();
    }

    // Is called when any collider enters trigger of platform
    private void OnTriggerEnter(Collider collider)
    {
        CharacterController _characterController = collider.gameObject.GetComponent<CharacterController>();
        if (_characterController != null)
            CharactersInWindZoneList.Add(_characterController);
    }

    // Is called when collider exits platform
    private void OnTriggerExit(Collider collider)
    {
        CharacterController _characterController = collider.gameObject.GetComponent<CharacterController>();
        if (_characterController != null)
            CharactersInWindZoneList.Remove(_characterController);
    }
    private void ChangeWindDirection()
    {
        System.Random random = new System.Random();
        int randomDir = random.Next(0, _arrayOfVectors.Length);
        _windDirection = _arrayOfVectors[randomDir];
        StartCoroutine(ChangeWindCoroutine());
    }

    // Is called every fixed frame rate.
    private void FixedUpdate()
    {
        if (CharactersInWindZoneList.Count > 0)
        {
            foreach (CharacterController u in CharactersInWindZoneList)
            {
                u.Move(_windDirection * _windStrength * Time.deltaTime);
            }
        }
    }
    // Provides cooldown for wind direction change
    private IEnumerator ChangeWindCoroutine()
    {
        yield return new WaitForSeconds(_changeWindTime);
        Debug.Log("changing wind");
        ChangeWindDirection();
    }
}
