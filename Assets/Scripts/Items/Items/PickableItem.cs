using Items.PickDetector;
using Items.Picker;
using UnityEngine;

namespace Items
{
    public class PickableItem : MonoBehaviour, IPickable
    {
        public Item ItemContained => item;
        [SerializeField] private Item item;
        
        public IPickDetector PickDetector { get; private set; }

        private void Start()
        {
            PickDetector = gameObject.GetComponent<IPickDetector>() 
                           ?? gameObject.AddComponent<CommonPickDetector>();
            PickDetector.Picked += Picked;
        }

        private void Picked(IPicker picker) => picker.Pick(this);
    }
}