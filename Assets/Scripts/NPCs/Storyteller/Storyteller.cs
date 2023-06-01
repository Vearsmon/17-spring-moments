using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Scene;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace NPCs.Storyteller
{
    public class Storyteller : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;
        [SerializeField] private GameObject background;
        [SerializeField] private EscapeManager escapeManager;

        private readonly Stack<string> messagesToShow = new();

        public void HideStoryTeller()
        {
            background.SetActive(false);
        }
        
        public void ShowMessage(string message)
        {
            background.SetActive(true);
            text.text = message;
            escapeManager.AddCloseTask(HideStoryTeller);
        }

        public void ShowMessagesSequence(params string[] messages)
        {
            if (messages.Length == 0)
                return;

            foreach (var message in messages.Reverse())
                messagesToShow.Push(message);
            
            escapeManager.onClose.AddListener(ShowNextMessage);
            ShowMessage(messagesToShow.Pop());
        }

        private void ShowNextMessage()
        {
            if (messagesToShow.TryPop(out var message))
                ShowMessage(message);
            else
                escapeManager.onClose.RemoveListener(ShowNextMessage);
        }

        private void Start()
        {
            text ??= GetComponentInChildren<TextMeshProUGUI>();
            escapeManager = GameObject.FindGameObjectWithTag("EscapeManager")
                ?.GetComponent<EscapeManager>();
        }
    }
}
