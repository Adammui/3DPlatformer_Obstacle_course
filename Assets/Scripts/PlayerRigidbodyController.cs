using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;
    [SerializeField]
    private float JumpHeight = 2.0f;

    private Rigidbody _body; 
    private Vector3 _inputs = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ApplyMove();
        ApplyJump();
    }

    // handles moving with rigidbody
    private void ApplyMove()
    {
        //accessing predefined Unity axes
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        //character rotates with directional movement
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;
    }

    // handles jumping with rigidbody
    private void ApplyJump()
    {
        if (Input.GetButtonDown("Jump"))
        {

            //force applied continuously along direction of the force vector (Vector3.up). ForceMode.VelocityChange applies our change to the velocity
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange); 
        }
    }

    // Is called every fixed frame rate.
    void FixedUpdate() 
    {
        //New position for rigidbody
        _body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);  
    }

}
