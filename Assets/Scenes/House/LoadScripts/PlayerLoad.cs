using Items.Inventory;
using Model;
using UnityEngine;

namespace Scenes.House.LoadScripts
{
    public class PlayerLoad : MonoBehaviour
    {
        void Start()
        {
            gameObject.transform.position = Core.HouseState.PlayerPosition;
            gameObject.GetComponent<Inventory>().Items = Core.PlayerState.items;
        }
    }
}
