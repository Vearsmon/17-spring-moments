using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class EscapeManager : MonoBehaviour
    { 
        private Stack<Action> toClose = new();

        private DateTime cooldownTime;
        
        private void Update()
        {
            if (DateTime.Now < cooldownTime)
                return;
            
            if (Input.GetKey(KeyCode.Escape))
                Close();
        }

        public void AddCloseTask(Action action) => toClose.Push(action);

        public void Close()
        {
            if (!toClose.TryPop(out var action))
                return;
                
            action.Invoke();
            cooldownTime = DateTime.Now + TimeSpan.FromMilliseconds(100);
        }
    }
}
