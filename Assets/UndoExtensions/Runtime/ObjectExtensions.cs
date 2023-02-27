using System;
using Object = UnityEngine.Object;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GigaCreation.Tools.UndoExtensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Destroys the object.
        /// If in editor and not play mode, records an undo operation so that it can be recreated.
        /// </summary>
        /// <param name="self">The object that will be destroyed.</param>
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

        /// <summary>
        /// Execute the action.
        /// If in editor and not play mode, records any changes done on the object.
        /// </summary>
        /// <param name="self">The reference to the object you will be modifying.</param>
        /// <param name="name">The title of the action to appear in the undo history (i.e. visible in the undo menu).</param>
        /// <param name="undoableAction">The action you want to register an undo operation.</param>
        /// <typeparam name="T">The type of the reference to the object you will be modifying.</typeparam>
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
    }
}
