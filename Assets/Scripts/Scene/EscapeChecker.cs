using UnityEngine;
using UnityEngine.Events;

namespace Scene
{
    public class EscapeChecker : MonoBehaviour
    {
        public UnityEvent OnEsc;
        
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
                OnEsc.Invoke();
        }
    }
}
