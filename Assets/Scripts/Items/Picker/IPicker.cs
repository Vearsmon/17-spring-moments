using JetBrains.Annotations;
using UnityEngine;

namespace Items.Picker
{
    public interface IPicker
    {
        public GameObject target { get; }
        [CanBeNull] public Inventory TargetInventory { get; }
        
        public void Pick(PickableItem item);
    }
}