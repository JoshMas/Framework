using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramedWok.PlayerController
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerPhysics : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        private Collider playerCollider;

        [SerializeField] private float maxVelocity = 10.0f;
        [SerializeField, Tooltip("This value should be slightly more than half your player model's height")] private float groundCheckLength = 1.05f;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.freezeRotation = true;
            playerCollider = GetComponent<Collider>();
            if (playerCollider == null)
                playerCollider = gameObject.AddComponent<CapsuleCollider>();
        }

        public void AddGroundAcceleration(Vector3 acceleration)
        {
            playerRigidbody.AddForce(acceleration, ForceMode.VelocityChange);
            RestrictVelocity();
        }

        public void RestrictVelocity()
        {
            playerRigidbody.velocity = Vector3.ClampMagnitude(playerRigidbody.velocity, maxVelocity);
        }

        public void Rotate(Vector3 rotation)
        {
            transform.localEulerAngles = new Vector3(0, rotation.y, 0);
            Camera.main.transform.localEulerAngles = new Vector3(rotation.x, 0, 0);
        }

        public void Jump(float jumpStrength)
        {
            playerRigidbody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }

        public void Dash(Vector3 direction, float dashStrength, float dashDuration)
        {

        }

        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, Vector3.down, groundCheckLength);
        }
    }
}