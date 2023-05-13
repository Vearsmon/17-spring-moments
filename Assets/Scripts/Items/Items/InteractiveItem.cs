using Items.PickDetector;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    public class InteractiveItem : MonoBehaviour, IInteractive
    {
        public IInteractionDetector InteractionDetector { get; private set; }

        public UnityEvent<GameObject> Interacted;
        
        private void Start()
        {
            InteractionDetector = gameObject.GetComponent<IInteractionDetector>() 
                                  ?? gameObject.AddComponent<CommonInteractionDetector>();
            InteractionDetector.Interacted += obj => Interacted.Invoke(obj);
        }
    }
}