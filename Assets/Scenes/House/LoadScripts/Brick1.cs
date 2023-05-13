using Items;
using Items.PickDetector;
using Model;
using UnityEngine;

public class Brick1 : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetInstanceID();
        gameObject.GetComponent<IInteractionDetector>().Interacted += _ => Core.HouseState.Brick1 = false;
        if (!Core.HouseState.Brick1)
            Destroy(gameObject);
    }
}
