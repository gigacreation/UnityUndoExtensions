using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GigaCreation.Tools.UndoExtensions.Sample
{
    public class UndoExtensionsSample : MonoBehaviour
    {
        [SerializeField] private int _counter;

        public void IncrementCounter()
        {
            _counter++;
        }

        public void DecrementCounter()
        {
            _counter--;
        }

        public void IncrementCounterAsUndoable()
        {
            this.DoActionAsUndoable("Increment Counter", x => x.IncrementCounter());
        }

        public void DecrementCounterAsUndoable()
        {
            this.DoActionAsUndoable("Decrement Counter", x => x.DecrementCounter());
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
