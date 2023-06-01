using System;
using UnityEngine;

namespace NPCs.Muller
{
    public class MullerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigidbody;
        private static readonly int Walk = Animator.StringToHash("walk");
        private static readonly int Hurted = Animator.StringToHash("Hurted");

        private int damagedCount = 0;
        private static readonly int Fell = Animator.StringToHash("Fell");
        private const float FallingAnimationPositionOffset = 0.747f;

        private void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            animator.SetBool(Walk, Math.Abs(rigidbody.velocity.magnitude) >= 1e-1);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("DamagingItem"))
            {
                Destroy(col.gameObject);
                if (damagedCount++ == 0)
                    animator.SetBool(Hurted, true);
                else
                {
                    var pos = transform.position;
                    pos.x -= FallingAnimationPositionOffset;
                    transform.position = pos;
                    animator.SetBool(Fell, true);
                }
            }
        }
    }
}