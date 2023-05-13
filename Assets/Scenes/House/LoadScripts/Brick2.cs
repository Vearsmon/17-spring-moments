using System;
using System.Collections;
using System.Collections.Generic;
using Items;
using Items.PickDetector;
using Model;
using UnityEngine;

public class Brick2 : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<IInteractionDetector>().Interacted += _ => Core.HouseState.Brick2 = false;
        if (!Core.HouseState.Brick2)
            Destroy(gameObject);
    }
}
