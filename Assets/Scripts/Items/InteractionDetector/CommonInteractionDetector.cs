using System;
using UnityEngine;

namespace Items.InteractionDetector
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
            if (col.GetComponent<Player.Player>() == null) 
                return;
            isEntered = true;
            objectEntered = col.gameObject;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            isEntered = false;
        }
    }
}