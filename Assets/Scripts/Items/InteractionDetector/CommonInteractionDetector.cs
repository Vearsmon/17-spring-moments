using System;
using Items.Picker;
using JetBrains.Annotations;
using UnityEngine;

namespace Items.PickDetector
{
    public class CommonInteractionDetector : MonoBehaviour, IInteractionDetector
    {
        private GameObject objectEntered;
        public event Action<GameObject> Interacted;

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
                Interacted?.Invoke(objectEntered);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            isEntered = true;
            objectEntered = col.gameObject;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isEntered = false;
        }
    }
}