using System;
using System.Collections.Generic;
using Items;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private List<Image> icons = new List<Image>();

    public void UpdateUI(Inventory inventory)
    {
        var size = Math.Min(icons.Count, inventory.Count);
        for (var i = 0; i < size; i++)
        {
            icons[i].color = Color.white;
            icons[i].sprite = inventory[i].Icon;
        }
        for (var i = size; i < icons.Count; i++)
            icons[i].color = Color.clear;
    }
}
