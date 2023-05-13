using System;
using Items.Items;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

namespace Items.Picker
{
    public interface IPicker
    {
        public GameObject target { get; }
        [CanBeNull] public Inventory.Inventory TargetInventory { get; }

        public event Action OnPick;

        public void Pick(PickableItem item);
    }
}