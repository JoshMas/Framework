using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace FramedWok.PlayerController
{
    [CustomEditor(typeof(FirstPersonPlatformerController))]
    public class PlayerControllerEditor : Editor
    {
        private FirstPersonPlatformerController controller;
    }
}