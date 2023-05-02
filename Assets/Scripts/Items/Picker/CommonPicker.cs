using System;
using UnityEngine;

namespace Items.Picker
{
    public class CommonPicker : MonoBehaviour, IPicker
    {
        public GameObject target { get; private set; }
        public Inventory TargetInventory { get; private set; }
        
        public event Action OnPick;

        private void Start()
        {
            target = gameObject;
            TargetInventory = gameObject.GetComponent<Inventory>();
        }

        public void Pick(PickableItem item)
        {
            if (TargetInventory != null && TargetInventory.TryAddItem(item.ItemContained))
            {
                OnPick?.Invoke();
                Destroy(item.gameObject);
            }
            else
                Debug.Log("Full Inventory");
        }
    }
}