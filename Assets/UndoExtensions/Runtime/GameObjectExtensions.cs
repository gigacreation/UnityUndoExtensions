// ReSharper disable ConvertIfStatementToReturnStatement

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GigaCreation.Tools.UndoExtensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Adds a component to the GameObject.
        /// If in editor and not play mode, registers an undo operation for this action.
        /// </summary>
        /// <param name="self">The GameObject you want to add the component to.</param>
        /// <typeparam name="T">The type of component you want to add.</typeparam>
        /// <returns>Component The newly added component.</returns>
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
