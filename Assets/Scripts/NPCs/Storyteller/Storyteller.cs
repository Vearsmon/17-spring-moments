using System;
using TMPro;
using UnityEngine;

namespace NPCs.Storyteller
{
    public class Storyteller : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void ShowMessage(string message)
        {
            gameObject.SetActive(true);
            text.text = message;
        }

        public void HideStoryTeller()
        {
            gameObject.SetActive(false);
        }
        
        private void Start()
        {
            text ??= GetComponentInChildren<TextMeshProUGUI>();
        }
    }
}
