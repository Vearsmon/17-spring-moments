using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMover : MonoBehaviour
{
    [SerializeField] public GameObject to;
    [SerializeField] public float speed = 3;
    
    private Vector2 direction;
    private Vector2 toPos;
    private Rigidbody2D rigidbody;
    
    void Start()
    {
        toPos = to.transform.position;
        direction = (toPos - (Vector2)gameObject.transform.position).normalized * speed;

        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        rigidbody.velocity = direction;
    }

    void FixedUpdate()
    {
        var currentPosition = (Vector2)gameObject.transform.position;
        if ((toPos - currentPosition).magnitude < 1e-1)
        {
            Destroy(this);
            rigidbody.velocity = Vector2.zero;
            return;
        }

        // gameObject.transform.position = currentPosition + direction * Time.deltaTime;

    }
}
