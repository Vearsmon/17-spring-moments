using Items;
using Model;
using UnityEngine;

public class PlayerLoad : MonoBehaviour
{
    void Start()
    {
        gameObject.transform.position = Core.HouseState.PlayerPosition;
        gameObject.GetComponent<Inventory>().Items = Core.PlayerState.items;
    }
}
