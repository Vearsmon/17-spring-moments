using Items.PickDetector;
using Items.Picker;
using UnityEngine;

namespace Items
{
    public class PickableItem : MonoBehaviour, IInteractive
    {
        public Item ItemContained => item;
        [SerializeField] private Item item;
        
        public IInteractionDetector InteractionDetector { get; private set; }

        private void Start()
        {
            InteractionDetector = gameObject.GetComponent<IInteractionDetector>() 
                           ?? gameObject.AddComponent<CommonInteractionDetector>();
            InteractionDetector.Interacted += Interacted;
        }

        private void Interacted(GameObject obj) => obj.GetComponent<IPicker>()?.Pick(this);
    }
}