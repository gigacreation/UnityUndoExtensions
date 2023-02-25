using UnityEditor;
using UnityEngine;

namespace GigaCreation.Tools.UndoExtensions.Sample.Editor
{
    [CustomEditor(typeof(UndoExtensionsSample))]
    public class UndoExtensionsSampleEditor : UnityEditor.Editor
    {
        private const string InfoMessage
            = "Make sure that the scene is marked dirty when you execute undoable methods.";

        private SerializedProperty _counterProperty;

        private void OnEnable()
        {
            _counterProperty = serializedObject.FindProperty("Counter");
        }

        public override void OnInspectorGUI()
        {
            if (target is not UndoExtensionsSample undoExtensionsSample)
            {
                return;
            }

            EditorGUILayout.Space();
            EditorGUILayout.HelpBox(InfoMessage, MessageType.Info);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("### Modify Field ###", EditorStyles.boldLabel);
            serializedObject.Update();
            EditorGUILayout.PropertyField(_counterProperty);
            serializedObject.ApplyModifiedProperties();

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Increment Counter", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.IncrementCounter();
                }

                if (GUILayout.Button("Decrement Counter", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.DecrementCounter();
                }
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Increment Counter as Undoable", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.IncrementCounterAsUndoable();
                }

                if (GUILayout.Button("Decrement Counter as Undoable", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.DecrementCounterAsUndoable();
                }
            }

            EditorGUILayout.Space();
            EditorGUI.DrawRect(EditorGUILayout.GetControlRect(false, 1f), Color.gray);
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("### Modify Component ###", EditorStyles.boldLabel);

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Add Component", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.AddSampleComponent();
                }

                if (GUILayout.Button("Destroy Component", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.DestroySampleComponent();
                }
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("Add Component as Undoable", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.AddSampleComponentAsUndoable();
                }

                if (GUILayout.Button("Destroy Component as Undoable", GUILayout.Height(24f)))
                {
                    undoExtensionsSample.DestroySampleComponentAsUndoable();
                }
            }
        }
    }
}
