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
            Debug.Log("Hurted");
            if (col.gameObject.CompareTag("DamagingItem"))
            {
                Destroy(col.gameObject);
                animator.SetBool(damagedCount++ == 0 ? Hurted : Fell, true);
            }
        }
    }
}