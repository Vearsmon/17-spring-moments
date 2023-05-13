using Model;
using UnityEngine;
using UnityEngine.Events;

namespace Scenes.House.PuzzleScene.Scene_Scripts
{
    public class CoreAdapter : MonoBehaviour
    {
        public UnityEvent OnSolved;

        public int CurrentState;
        
        public void PressButton(int buttonNumber)
        {
            Core.HouseState.TablePuzzle.ChangeState(buttonNumber);
            CurrentState = Core.HouseState.TablePuzzle.CurrentState;
            if (Core.HouseState.TablePuzzle.Solved)
            {
                OnSolved?.Invoke();
                Debug.Log("Solved");
            }
        }
    }
}
