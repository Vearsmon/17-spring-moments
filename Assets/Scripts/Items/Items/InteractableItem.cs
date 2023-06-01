using Items.InteractionDetector;
using UnityEngine;
using UnityEngine.Events;

namespace Items.Items
{
    public class InteractableItem : MonoBehaviour, IInteractable
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