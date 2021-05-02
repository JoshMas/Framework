using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace FramedWok.PlayerController
{
    /// <summary>
    /// Custom editor for the First Person Player Controller
    /// </summary>
    [CustomEditor(typeof(FirstPersonPlatformerController))]
    public class PlayerControllerEditor : Editor
    {
        private FirstPersonPlatformerController controller;

        private SerializedProperty walkAccelerationProperty;
        private SerializedProperty maxVelocityProperty;
        private SerializedProperty rateOfRestrictionProperty;

        private SerializedProperty canJumpProperty;
        private SerializedProperty airControlProperty;
        private SerializedProperty jumpStrengthProperty;
        private SerializedProperty numberOfJumpsProperty;

        private SerializedProperty canDashProperty;
        private SerializedProperty horizontalDashOnlyProperty;
        private SerializedProperty dashStrengthProperty;
        private SerializedProperty dashDurationProperty;

        private AnimBool canJump = new AnimBool();
        private AnimBool canDash = new AnimBool();

        private void OnEnable()
        {
            controller = target as FirstPersonPlatformerController;

            walkAccelerationProperty = serializedObject.FindProperty("walkAcceleration");
            maxVelocityProperty = serializedObject.FindProperty("maxVelocity");
            rateOfRestrictionProperty = serializedObject.FindProperty("rateOfRestriction");

            canJumpProperty = serializedObject.FindProperty("canJump");
            airControlProperty = serializedObject.FindProperty("airControl");
            jumpStrengthProperty = serializedObject.FindProperty("jumpStrength");
            numberOfJumpsProperty = serializedObject.FindProperty("numberOfJumps");

            canDashProperty = serializedObject.FindProperty("canDash");
            horizontalDashOnlyProperty = serializedObject.FindProperty("horizontalDashOnly");
            dashStrengthProperty = serializedObject.FindProperty("dashStrength");
            dashDurationProperty = serializedObject.FindProperty("dashDuration");

            canJump.value = canJumpProperty.boolValue;
            canJump.valueChanged.AddListener(Repaint);
            canDash.value = canDashProperty.boolValue;
            canDash.valueChanged.AddListener(Repaint);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.PropertyField(walkAccelerationProperty);
                EditorGUILayout.PropertyField(maxVelocityProperty);
                EditorGUILayout.PropertyField(rateOfRestrictionProperty);
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.PropertyField(canJumpProperty);

                canJump.target = canJumpProperty.boolValue;

                if (EditorGUILayout.BeginFadeGroup(canJump.faded))
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.PropertyField(airControlProperty);
                    EditorGUILayout.PropertyField(jumpStrengthProperty);
                    EditorGUILayout.PropertyField(numberOfJumpsProperty);

                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndVertical();


            EditorGUILayout.BeginVertical(GUI.skin.box);
            {
                EditorGUILayout.PropertyField(canDashProperty);

                canDash.target = canDashProperty.boolValue;

                if (EditorGUILayout.BeginFadeGroup(canDash.faded))
                {
                    EditorGUI.indentLevel++;

                    EditorGUILayout.PropertyField(horizontalDashOnlyProperty);
                    EditorGUILayout.PropertyField(dashStrengthProperty);
                    EditorGUILayout.PropertyField(dashDurationProperty);

                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.EndFadeGroup();
            }
            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}