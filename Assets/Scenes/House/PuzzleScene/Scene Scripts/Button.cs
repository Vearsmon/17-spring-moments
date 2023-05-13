using System;
using UnityEngine;

namespace Scenes.House.PuzzleScene.Scene_Scripts
{
    public class Button : MonoBehaviour
    {
        public bool Interactable { get; set; } = true;
        
        private bool isPressed;

        private SpriteRenderer spriteRenderer;
        private static readonly Color OffsetColor = new (0.2f, 0.2f, 0.2f, 0f);
        private Color startColor;

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            startColor = spriteRenderer.color;
        }

        public void Press()
        {
            if (isPressed || !Interactable)
                return;
            isPressed = true;
            spriteRenderer.color -= OffsetColor;
        }

        public void Release()
        {
            isPressed = false;
            spriteRenderer.color = startColor;
        }
    }
}
