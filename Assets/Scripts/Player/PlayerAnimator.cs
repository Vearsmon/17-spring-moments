using System;
using System.Threading;
using Items.Picker;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Player
{
    public enum Direction {Forward, Down, Left, Right}

    public class PlayerAnimator : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigidbody;
        [SerializeField] private IPicker picker;
        [SerializeField] public AudioClip[] StepsAudioClips;
    
        private static readonly int Direction1 = Animator.StringToHash("Direction");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Pick = Animator.StringToHash("Pick");

        public AudioSource audio;
        private Direction previousDirection;
        private float speed;
        private int timer;
    
        private DateTime pickStarted = DateTime.Now;
    
        private void Start()
        {
            audio = GetComponent<AudioSource>();
            picker = gameObject.GetComponent<IPicker>();
            picker.OnPick += StartPickAnimation;
            
            previousDirection = Direction.Down;
        }

        private void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
                Input.GetKey(KeyCode.D))
            {
                print(timer);
                timer++;
                if (timer > 25 && Math.Abs(rigidbody.velocity.magnitude) >= 1e-3)
                {
                    MakeStepSound();
                    timer = 0;
                }
            }
            
            ChangeDirectionParameter();
            ChangeSpeedParameter();
            ChangePicking();
        }

        private void ChangeSpeedParameter()
        {
            var velocity = rigidbody.velocity.magnitude;
            if (Math.Abs(speed - velocity) < 1e-3)
                return;

            speed = velocity;
            animator.SetFloat(Speed, velocity);
        }

        private void ChangeDirectionParameter()
        {
            var dir = GetDirection();
            if (dir == previousDirection)
                return;
            
            previousDirection = dir;
            animator.SetInteger(Direction1, (int)dir);
        }

        private Direction GetDirection()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            if (Math.Abs(x) < 1e-3 && Math.Abs(y) < 1e-3)
                return previousDirection;

            if (Math.Abs(x) > Math.Abs(y))
                return x < 0 ? Direction.Left : Direction.Right;
            return y < 0 ? Direction.Forward : Direction.Down;
        }

        private void ChangePicking()
        {
            if ((DateTime.Now - pickStarted).Milliseconds > 100)
                animator.SetBool(Pick, false);
        }

        private void StartPickAnimation()
        {
            pickStarted = DateTime.Now;
            animator.SetBool(Pick, true);
        }

        private void MakeStepSound()
        {
            audio.PlayOneShot(StepsAudioClips[Random.Range(0, StepsAudioClips.Length)]);
        }
    }
}