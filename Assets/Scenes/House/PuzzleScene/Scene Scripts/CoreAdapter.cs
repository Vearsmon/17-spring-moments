using System;
using Model;
using UnityEngine;
using UnityEngine.Events;
using NPCs.Storyteller;
using Scene.HousePuzzle;

namespace Scenes.House.PuzzleScene.Scene_Scripts
{
    public class CoreAdapter : MonoBehaviour
    {
        public UnityEvent onFirstLoad;
        public UnityEvent onSolved;

        private Button[] buttons;
        private DateTime startReleasing = DateTime.MaxValue;
        private static readonly TimeSpan Duration = new (0, 0, 0, 0, 300);

        private static int loadCount = 0;

        private void Start()
        {
            if (loadCount++ == 0)
                onFirstLoad.Invoke();
            
            GameObject.FindGameObjectWithTag("EscapeManager").GetComponent<EscapeManager>().ifToCloseStackEmpty
                .Add(FindObjectOfType<PuzzleHouseSceneChanger>().Exit);

            buttons = FindObjectsByType<Button>(FindObjectsSortMode.None);
            if (Core.HouseState.TablePuzzle.Solved)
                BlockButtons();
        }

        private void FixedUpdate()
        {
            if (DateTime.Now - startReleasing >= Duration)
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
                GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller>().ShowMessagesSequence(
                    "из трубки донесся записанный ранее томный голос Бормана.".ToUpper(),
                    "балбес - подумал Штирлиц".ToUpper(),
                    "Мюллер, не забудьте взять документ под номером 34! - говорил томный голос Бормана".ToUpper());
                onSolved?.Invoke();
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
