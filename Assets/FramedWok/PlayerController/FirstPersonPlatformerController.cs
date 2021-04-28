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

        // Start is called before the first frame update
        void Start()
        {
            input = GetComponent<PlayerInput>();
            physics = GetComponent<PlayerPhysics>();
        }

        // Update is called once per frame
        void Update()
        {
            physics.Rotate(input.GetCameraRotation());
        }
    }
}