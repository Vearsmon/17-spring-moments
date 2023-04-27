using System;
using Items.Picker;
using JetBrains.Annotations;
using UnityEngine;

namespace Items.PickDetector
{
    public class CommonPickDetector : MonoBehaviour, IPickDetector
    {
        public event Action<IPicker> Picked;

        [CanBeNull] private IPicker pickerEntered;
        private bool isEntered;
        
        public void Start()
        {
            if (GetComponentInParent<Collider2D>() == null)
                gameObject.AddComponent<BoxCollider2D>();
        }

        public void FixedUpdate()
        { 
            if (!isEntered)
                return;
            
            if (Input.GetKey(KeyCode.E))
                Picked?.Invoke(pickerEntered);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            pickerEntered = col.gameObject.GetComponent<IPicker>();
            if (pickerEntered != null)
                isEntered = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isEntered = false;
        }
    }
}