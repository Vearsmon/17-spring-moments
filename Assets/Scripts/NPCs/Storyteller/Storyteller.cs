using System;
using Model;
using Scene;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

namespace NPCs.Storyteller
{
    public class Storyteller : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GameObject background;

        private EscapeManager escapeManager;

        public void ShowMessage(string message)
        {
            background.SetActive(true);
            text.text = message;
            escapeManager.AddCloseTask(HideStoryTeller);
        }

        public void HideStoryTeller()
        {
            background.SetActive(false);
        }
        
        private void Start()
        {
            text ??= GetComponentInChildren<TextMeshProUGUI>();
            escapeManager = GameObject.FindGameObjectWithTag("EscapeManager")
                ?.GetComponent<EscapeManager>();
        }
    }
}
