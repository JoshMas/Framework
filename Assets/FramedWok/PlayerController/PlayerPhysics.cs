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

        private Vector3 appliedLinearVelocity = Vector3.zero;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            playerRigidbody.freezeRotation = true;
            playerCollider = GetComponent<Collider>();
            if (playerCollider == null)
                playerCollider = gameObject.AddComponent<CapsuleCollider>();
        }

        public void SetVelocity(Vector3 velocity)
        {
            appliedLinearVelocity += velocity;
        }

        public void Rotate(Vector3 rotation)
        {
            transform.localEulerAngles = rotation;

        }
    }
}