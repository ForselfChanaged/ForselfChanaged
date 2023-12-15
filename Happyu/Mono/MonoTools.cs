using UnityEngine.Events;

namespace Happyu { 
    public class MonoTools : MonoSingleton<MonoTools>
    {
        private event UnityAction OnUpdateCallback;
        public event  UnityAction OnGuiCallback;
        private void Update()
        {
            OnUpdateCallback?.Invoke();
        }
        private void OnGUI()
        {
            OnGuiCallback?.Invoke();
        }
    }

}

