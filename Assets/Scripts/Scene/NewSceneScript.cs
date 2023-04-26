using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewSceneScript : MonoBehaviour
{
    [SerializeField]
    private GameObject floor1;

    private SpriteRenderer[] floor1Sprites;

    private float floor1Alpha;

    private void Start()
    {
        floor1.SetActive(true);

        floor1Sprites = floor1.GetComponentsInChildren<SpriteRenderer>();

        floor1Alpha = 1;
    }

    private void Update()
    {
        foreach (var sprite in floor1Sprites)
        {
            var color = sprite.color;
            color.a = floor1Alpha;
            sprite.color = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            SceneManager.LoadScene("Balcony");
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        var alpha = (col.gameObject.transform.position.y - transform.position.y)
                    / (GetComponent<BoxCollider2D>().size.y * transform.localScale.y) 
                    + 0.5f;

        alpha = Math.Clamp(alpha, 0, 1);
        alpha *= alpha;

        floor1Alpha = 1 - alpha;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (floor1Alpha > 0.5)
        {
            floor1.SetActive(true);
        }
        else
        {
            floor1.SetActive(false);
        }
    }
}