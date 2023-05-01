using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FloorSwitcher : MonoBehaviour
{
    public VectorValue floor1AlphaChangeable;
    
    [SerializeField]
    private GameObject floor1;

    private SpriteRenderer[] floor1Sprites;

    private float floor1Alpha;
    
    [SerializeField]
    private GameObject floor2;
    
    private SpriteRenderer[] floor2Sprites;

    private float floor2Alpha;

    private Vector2 exitPosition = new (7.5f, 3.3f);
    
    private void Start()
    {
        floor1Alpha = floor1AlphaChangeable.floorAlpha;
        
        if (floor1Alpha > 0.5)
        {
            floor1.SetActive(true);
            floor2.SetActive(false);
        }
        else
        {
            floor1.SetActive(false);
            floor2.SetActive(true);
        }

        floor1Sprites = floor1.GetComponentsInChildren<SpriteRenderer>();
        floor2Sprites = floor2.GetComponentsInChildren<SpriteRenderer>();
        
        floor2Alpha = 1 - floor1Alpha;
    }

    private void Update()
    {
        foreach (var sprite in floor1Sprites)
        {
            var color = sprite.color;
            color.a = floor1Alpha;
            sprite.color = color;
        }
        
        foreach (var sprite in floor2Sprites)
        {
            var color = sprite.color;
            color.a = floor2Alpha;
            sprite.color = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        floor1.SetActive(true);
        floor2.SetActive(true);
    }

    private void TurnOn2Floor(Collider2D col)
    {
        floor2.SetActive(true);
        floor1.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        var alpha = (col.gameObject.transform.position.y - transform.position.y)
                    / (GetComponent<BoxCollider2D>().size.y * transform.localScale.y) 
                    + 0.5f;

        alpha = Math.Clamp(alpha, 0, 1);
        alpha *= alpha;

        floor1Alpha = 1 - alpha;
        floor2Alpha = alpha;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (floor1Alpha > 0.5)
        {
            floor1.SetActive(true);
            floor2.SetActive(false);
        }
        else
        {
            floor1.SetActive(false);
            floor2.SetActive(true);
        }
    }
}
