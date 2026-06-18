using UnityEngine;
using UnityEngine.InputSystem;

namespace Gameplay.Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private float gravityMultiplier = 3.0f;
        [SerializeField] private float speed;
        [SerializeField] private float smoothTime = 0.05f;
        [SerializeField] private float jumpPower;
        [SerializeField] private Animator animator;
        
        private Vector2 _input;
        private Vector3 _direction;
        private float _currentVelocity;
        private float _gravity = -9.81f;
        private float _velocity;
        public float Velocity => _velocity;
        public bool IsGrounded() => _characterController.isGrounded;

        // Update is called once per frame
        public void OnUpdate()
        {
            ApplyGravity();
            ApplyRotation();
            ApplyMovement();
        }

        // Handling player gravity with simple formula
        private void ApplyGravity()
        {
            if (IsGrounded() && _velocity < 0.0f)
            {
                _velocity = -1.0f;
            }
            else
            {
                _velocity += _gravity * gravityMultiplier * Time.deltaTime;
            }
            _direction.y = _velocity;
        }

        // Handling rotation of player object in direction of movement
        private void ApplyRotation()
        {
            if (_input.sqrMagnitude == 0) return;

            var targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
            transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f);
        }

        // Moves player with character controller method
        private void ApplyMovement()
        {
            _characterController.Move(_direction * speed * Time.deltaTime);
        }

        // Handling movement function from Input System
        public void Move(InputAction.CallbackContext context)
        {
            _input = context.ReadValue<Vector2>();
            _direction = new Vector3(_input.x, 0.0f, _input.y);
            if (_direction != Vector3.zero)
            {
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isWalking", false);
            }
        }

        // Handling jump function from Input System
        public void Jump(InputAction.CallbackContext context)
        {
            if (!context.started) return;
            if (!IsGrounded()) return;

            _velocity += jumpPower;
        }
    }
}