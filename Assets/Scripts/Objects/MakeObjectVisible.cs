using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeObjectVisible : MonoBehaviour
{
    private Image sprite;
    void Start()
    {
        sprite = GetComponent<Image>();
    }

    IEnumerable VisibleSprite()
    {
        for (var f = 1f; f >= -0.05f; f -= 0.05f)
        {
            var material = sprite.material;
            var color = material.color;
            color.a = f;
            material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartVisible()
    {
        StartCoroutine("VisibleSprite");
    }
}
