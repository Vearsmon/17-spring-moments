using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToHouse : MonoBehaviour
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
            
            SceneManager.LoadScene("SampleScene");
            
        }
    }
}
