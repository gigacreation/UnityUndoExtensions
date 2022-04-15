using System;
using JetBrains.Annotations;
using UnityEngine;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GigaceeTools
{
    [UsedImplicitly(ImplicitUseTargetFlags.Members)]
    public static class UndoExtensions
    {
        public static void DoActionAsUndoable<T>(this T self, string name, Action<T> undoableAction) where T : Object
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
                Undo.RecordObject(self, name);
            }
#endif

            undoableAction(self);

#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
                EditorUtility.SetDirty(self);
            }
#endif
        }

        public static T AddComponentAsUndoable<T>(this GameObject self) where T : Component
        {
#if UNITY_EDITOR
            // ReSharper disable once ConvertIfStatementToReturnStatement
            if (!EditorApplication.isPlaying)
            {
                return Undo.AddComponent<T>(self);
            }
#endif

            return self.AddComponent<T>();
        }

        public static void DestroyAsUndoable(this Object self)
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
                Undo.DestroyObjectImmediate(self);
                return;
            }
#endif

            Object.Destroy(self);
        }
    }
}
