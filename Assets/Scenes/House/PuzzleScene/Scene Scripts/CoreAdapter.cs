using System;
using System.Threading;
using Model;
using UnityEngine;
using UnityEngine.Events;
using System.Threading.Tasks;

namespace Scenes.House.PuzzleScene.Scene_Scripts
{
    public class CoreAdapter : MonoBehaviour
    {
        public UnityEvent OnSolved;

        private Button[] buttons;
        private DateTime startReleasing = DateTime.MaxValue;
        private static readonly TimeSpan duration = new (0, 0, 0, 0, 200);

        private void Start()
        {
            buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
            if (Core.HouseState.TablePuzzle.Solved)
                BlockButtons();
        }

        private void FixedUpdate()
        {
            if (DateTime.Now - startReleasing >= duration)
            {
                ReleaseButtons();
                startReleasing = DateTime.MaxValue;
            }
        }

        public void PressButton(int buttonNumber)
        {
            Core.HouseState.TablePuzzle.ChangeState(buttonNumber);
            if (Core.HouseState.TablePuzzle.Solved)
            {                
                BlockButtons();
                OnSolved?.Invoke();
            }
            else if (Core.HouseState.TablePuzzle.InStartState)
            {
                BlockButtons();
                startReleasing = DateTime.Now;
            }
        }

        private void BlockButtons()
        {
            foreach (var button in buttons)
                button.Interactable = false;
        }
        
        private void ReleaseButtons()
        {
            foreach (var button in buttons)
            {
                button.Interactable = true;
                button.Release();
            }
        }
    }
}
