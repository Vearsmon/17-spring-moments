using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeObjectInvisible : MonoBehaviour
{
    private Image sprite;
    void Start()
    {
        sprite = GetComponent<Image>();
        var material = sprite.material;
        var color = material.color;
        color.a = 0f;
        material.color = color;
    }

    IEnumerable InvisibleSprite()
    {
        for (var f = 0.05f; f <= 1; f += 0.05f)
        {
            var material = sprite.material;
            var color = material.color;
            color.a = f;
            material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartInvisible()
    {
        StartCoroutine("InvisibleSprite");
    }
}
