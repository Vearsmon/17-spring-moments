using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using Model;
using UnityEngine;

public class Brick2 : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<PickableItem>().PickDetector.Picked += _ => Core.HouseState.Brick2 = false;
        if (!Core.HouseState.Brick2)
            Destroy(gameObject);
    }
}
