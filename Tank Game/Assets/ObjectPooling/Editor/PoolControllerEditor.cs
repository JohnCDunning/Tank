using UnityEngine;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;

namespace ObjectPooling
{
    [CustomEditor(typeof(PoolController))]
    public class PoolControllerEditor : Editor
    {
        private ReorderableList list;

        private void OnEnable()
        {
            list = new ReorderableList(serializedObject, serializedObject.FindProperty("poolPrefabs"), true, true, true, true);

            //public ReorderableList(
            //SerializedObject serializedObject,
            //SerializedProperty elements,
            //bool draggable,
            //bool displayHeader,
            //bool displayAddButton,
            //bool displayRemoveButton);

            list.drawHeaderCallback = (Rect rect) => {
                EditorGUI.LabelField(rect, "Object Pool Items");
            };

            list.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
                var element = list.serializedProperty.GetArrayElementAtIndex(index);
                rect.y += 2;
                EditorGUI.PropertyField(new Rect(rect.x, rect.y, 60, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("Name"), GUIContent.none);
                EditorGUI.PropertyField(new Rect(rect.x + 60, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("PrefabObject"), GUIContent.none);
                EditorGUI.PropertyField(new Rect(rect.x + rect.width - 30, rect.y, 30, EditorGUIUtility.singleLineHeight),
                element.FindPropertyRelative("Amount"), GUIContent.none);
            };

        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            GUILayout.Space(20);
            GUILayout.Label("Object Pool Items");
            GUILayout.Label("Name (string) | Prefab (obj) | Amount (int)");
            GUILayout.Space(20);

            list.DoLayoutList();

            GUILayout.Space(20);

            serializedObject.ApplyModifiedProperties();

        }
    }
}
