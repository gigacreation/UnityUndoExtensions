// ReSharper disable ArrangeObjectCreationWhenTypeEvident

using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GigaCreation.Tools.UndoExtensions.Sample
{
    public class UndoExtensionsSample : MonoBehaviour
    {
        public int Counter;

        public void IncrementCounter()
        {
            Counter++;
        }

        public void DecrementCounter()
        {
            Counter--;
        }

        public void IncrementCounterAsUndoable()
        {
            this.DoActionAsUndoable("Increment Counter", x =>
            {
                x.Counter++;
            });
        }

        public void DecrementCounterAsUndoable()
        {
            this.DoActionAsUndoable("Decrement Counter", x =>
            {
                x.Counter--;
            });
        }

        public void AddSampleComponent()
        {
            gameObject.AddComponent<SampleComponent>();
        }

        public void DestroySampleComponent()
        {
            if (TryGetComponent(out SampleComponent comp))
            {
#if UNITY_EDITOR
                if (!EditorApplication.isPlaying)
                {
                    DestroyImmediate(comp);
                    return;
                }
#endif

                Destroy(comp);
            }
        }

        public void AddSampleComponentAsUndoable()
        {
            gameObject.AddComponentAsUndoable<SampleComponent>();
        }

        public void DestroySampleComponentAsUndoable()
        {
            if (TryGetComponent(out SampleComponent comp))
            {
                comp.DestroyAsUndoable();
            }
        }
    }
}
