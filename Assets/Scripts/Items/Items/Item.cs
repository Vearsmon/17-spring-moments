using System;
using UnityEngine;

namespace Items.Items
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public Guid Id { get; } = Guid.NewGuid();

        public string Name => name;
        [SerializeField] private string name;
    }
}