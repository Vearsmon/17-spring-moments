using Items.ClickDetector;
using UnityEngine;
using UnityEngine.Events;

namespace Items.Items
{
    public class ClickableItem : MonoBehaviour, IClickable
    {
        public IClickDetector ClickDetector { get; private set; }
        
        public UnityEvent Clicked;
        
        private void Start()
        {
            ClickDetector = gameObject.GetComponent<IClickDetector>() 
                            ?? gameObject.AddComponent<CommonClickDetector>();
            ClickDetector.Clicked += () => Clicked?.Invoke();
        }
    }
}