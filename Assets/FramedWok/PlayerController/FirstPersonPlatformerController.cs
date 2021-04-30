using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FramedWok.PlayerController
{
    [RequireComponent(typeof(PlayerInput))]
    [RequireComponent(typeof(PlayerPhysics))]
    public class FirstPersonPlatformerController : MonoBehaviour
    {
        private PlayerInput input;
        private PlayerPhysics physics;

        [SerializeField] private float walkAcceleration = 100.0f;

        [SerializeField] private bool canJump = true;
        [SerializeField, Range(0, 1)] private float airControl = 1.0f;
        [SerializeField] private float jumpStrength = 10.0f;
        [SerializeField, Tooltip("The number of times the player can jump before landing")] private int numberOfJumps = 1;
        private int jumpCounter = 0;
        private bool isGrounded = true;

        [SerializeField] private bool canDash = true;
        [SerializeField, Tooltip("Restrict the dash to the XZ plane")] private bool horizontalDashOnly = false;
        [SerializeField] private float dashStrength = 100.0f;
        [SerializeField] private float dashDuration = 0.1f;

        // Start is called before the first frame update
        void Start()
        {
            input = GetComponent<PlayerInput>();
            physics = GetComponent<PlayerPhysics>();
        }

        // Update is called once per frame
        void Update()
        {
            physics.AddGroundAcceleration(input.GetGroundMovementVector() * walkAcceleration * Time.deltaTime * (isGrounded ? 1 : airControl));
            physics.Rotate(input.GetCameraRotation());

            if (Input.GetKeyDown(input.jumpKey) && canJump && jumpCounter < numberOfJumps)
            {
                physics.Jump(jumpStrength);
                jumpCounter++;
                isGrounded = false;
            }


        }

        private void OnCollisionEnter(Collision collision)
        {
            isGrounded = physics.IsGrounded();
            if (isGrounded)
                jumpCounter = 0;
        }
    }
}