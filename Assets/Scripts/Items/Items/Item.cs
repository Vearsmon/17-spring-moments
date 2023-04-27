using UnityEngine;

namespace Items
{
    [CreateAssetMenu]
    public class Item : ScriptableObject
    {
        public int Id => id;

        public string Name => name;
        public Sprite Icon => icon;

        [SerializeField] private int id;

        [SerializeField] private string name;
        [SerializeField] private Sprite icon;
    }
}