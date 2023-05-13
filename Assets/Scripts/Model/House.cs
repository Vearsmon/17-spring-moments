using UnityEngine;

namespace Model
{
    public class House
    {
        public Vector3 PlayerPosition { get; set; }

        public int CurrentFloor { get; set; } = 1;

        public bool Brick1 { get; set; } = true;
        public bool Brick2 { get; set; } = true;

        public Puzzle TablePuzzle = new Puzzle();

        public class Puzzle
        {
            public bool Solved { get; private set; }

            public int CurrentState { get; private set; }

            public const int WiningState = 6;

            public void ChangeState(int step)
            {
                if (CurrentState == WiningState)
                    return;

                if (CurrentState == step - 1)
                    CurrentState++;
                else
                    CurrentState = 0;

                if (CurrentState == WiningState)
                    Solved = true;
            }
        }
    }
}