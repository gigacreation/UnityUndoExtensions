using System;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GigaCreation.Tools.UndoExtensions
{
    public static class ObjectExtensions
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
