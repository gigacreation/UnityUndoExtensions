// ReSharper disable ConvertIfStatementToReturnStatement

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GigaCreation.Tools.UndoExtensions
{
    public static class GameObjectExtensions
    {
        public static T AddComponentAsUndoable<T>(this GameObject self) where T : Component
        {
#if UNITY_EDITOR
            if (!EditorApplication.isPlaying)
            {
                return Undo.AddComponent<T>(self);
            }
#endif

            return self.AddComponent<T>();
        }
    }
}
