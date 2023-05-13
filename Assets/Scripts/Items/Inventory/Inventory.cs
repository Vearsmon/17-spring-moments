using System.Collections.Generic;
using Items.Items;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace Items.Inventory
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] public List<Item> Items { get; set; }
        [SerializeField] private readonly int size = 3;
        
        [SerializeField] public UnityEvent OnInventoryChanged;
        public int Count => Items.Count;

        private void Start()
        {
            Items = Core.PlayerState.items;
        }

        public bool TryAddItem(Item item)
        {
            if (Items.Count >= size)
                return false;
            
            Items.Add(item);
            OnInventoryChanged?.Invoke();
            return true;
        }

        public Item this[int index] => index < Items.Count ? Items[index] : null;
    }
}