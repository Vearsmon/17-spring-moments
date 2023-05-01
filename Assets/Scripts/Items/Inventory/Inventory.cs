using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

namespace Items
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private List<Item> items = new();
        [SerializeField] private readonly int size = 3;
        
        [SerializeField] public UnityEvent OnInventoryChanged;
        
        public IEnumerable<Item> Items => items;
        public int Count => items.Count;
        
        public bool TryAddItem(Item item)
        {
            if (items.Count >= size)
                return false;
            
            items.Add(item);
            OnInventoryChanged?.Invoke();
            return true;
        }

        public Item this[int index] => index < items.Count ? items[index] : null;
    }
}