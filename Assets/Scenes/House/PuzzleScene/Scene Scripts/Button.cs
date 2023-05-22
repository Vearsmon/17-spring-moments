using System;
using UnityEngine;

namespace Scenes.House.PuzzleScene.Scene_Scripts
{
    public class Button : MonoBehaviour
    {
        public bool Interactable { get; set; } = true;
        public AudioClip pressSound;
        public AudioSource audio;
        
        private bool isPressed;

        private SpriteRenderer spriteRenderer;
        private Color releasedColor;
        private Color pressedColor;
        
        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
            pressedColor = spriteRenderer.color;
            releasedColor = Color.clear;

            spriteRenderer.color = releasedColor;
        }

        public void Press()
        {
            audio.PlayOneShot(pressSound);
            if (isPressed || !Interactable)
                return;
            isPressed = true;
            spriteRenderer.color = pressedColor;
        }

        public void Release()
        {
            isPressed = false;
            spriteRenderer.color = releasedColor;
        }
    }
}
