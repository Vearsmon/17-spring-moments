using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Items.Inventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private List<Image> icons = new List<Image>();

        public void UpdateUI(Inventory inventory)
        {
            var size = Math.Min(icons.Count, (int)inventory.Count);
            for (var i = 0; i < size; i++)
            {
                icons[i].color = Color.white;
            }
            for (var i = size; i < icons.Count; i++)
                icons[i].color = Color.clear;
        }
    }
}
