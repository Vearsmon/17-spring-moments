using System;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.Events;

namespace Model
{
    public class EscapeManager : MonoBehaviour
    {
        public readonly List<Action> ifToCloseStackEmpty = new();
        private int currentEvent;
        
        private readonly Stack<(GameObject, Action)> toClose = new();
        private readonly HashSet<GameObject> objectsAdded = new();

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) 
                return;
            
            if (!TryClose())
                ExecuteIfToCloseStackEmpty();
        }

        public void AddCloseTask(Action action)
        {
            currentEvent = 0;
            toClose.Push((null, action));
        }
        
        public void AddObject(GameObject obj)
        {
            if (!objectsAdded.Add(obj))
                return;

            currentEvent = 0;
            toClose.Push((obj, () => obj.SetActive(false)));
        }

        public bool TryClose()
        {
            if (!toClose.TryPop(out var action))
                return false;
            
            action.Item2.Invoke();
            if (action.Item1 != null)
                objectsAdded.Remove(action.Item1);
            return true;
        }

        private void ExecuteIfToCloseStackEmpty()
        {
            if (currentEvent < ifToCloseStackEmpty.Count)
                ifToCloseStackEmpty[currentEvent++].Invoke();
        }
    }
}
