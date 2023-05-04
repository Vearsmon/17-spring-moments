using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using Model;
using UnityEngine;

public class Brick1 : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<PickableItem>().PickDetector.Picked += _ => Core.HouseState.Brick1 = false;
        if (!Core.HouseState.Brick1)
            Destroy(gameObject);
    }
}
