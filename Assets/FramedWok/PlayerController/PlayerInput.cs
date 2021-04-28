using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FramedWok.PlayerController
{
    /// <summary>
    /// Class that handles input for the first person platforming controller
    /// Uses the horizontal and vertical input axes for ground movement
    /// Default jump and dash buttons are Space and LeftShift respectively
    /// </summary>
    public class PlayerInput : MonoBehaviour
    {
        public KeyCode jumpKey = KeyCode.Space;
        public KeyCode dashKey = KeyCode.LeftShift;
        [SerializeField] private Vector2 mouseSensitivity = new Vector2(5.0f, 2.0f);

        public Vector2 GetGroundMovementVector()
        {
            return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        }

        public Vector3 GetCameraRotation()
        {
            Vector3 rotation = Vector3.up * Input.GetAxis("Mouse X") * mouseSensitivity.x - Vector3.right * Input.GetAxis("Mouse Y") * mouseSensitivity.y;
            rotation += transform.localEulerAngles;
            rotation.Set(rotation.x, rotation.y, 0);
            return rotation;
        }
    }
}