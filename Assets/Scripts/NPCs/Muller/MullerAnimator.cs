using System;
using UnityEngine;

namespace NPCs.Muller
{
    public class MullerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigidbody;
        private static readonly int Walk = Animator.StringToHash("walk");

        private void Start()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            animator.SetBool(Walk, Math.Abs(rigidbody.velocity.magnitude) >= 1e-1);
        }
    }
}