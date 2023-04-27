using UnityEngine;

namespace Items.Picker
{
    public class CommonPicker : MonoBehaviour, IPicker
    {
        private Player player;
        
        public CommonPicker(Player player)
        {
            this.player = player;
        }
        
        public void Pick(PickableItem item)
        {
            Destroy(item.gameObject);
        }
    }
}