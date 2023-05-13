using System;
using UnityEngine;

namespace Items.ClickDetector
{
    public class CommonClickDetector : MonoBehaviour, IClickDetector
    {
        public event Action Clicked;

        private bool isMouseOver;

        private void Update()
        {
            if (!isMouseOver)
                return;
            
            if (Input.GetMouseButtonDown(0))
                Clicked?.Invoke();
        }

        private void OnMouseEnter()
        {
            isMouseOver = true;
        }

        private void OnMouseExit()
        {
            isMouseOver = false;
        }
    }
}
