using System;
using System.Collections.Generic;
using UnityEngine;

namespace Model
{
    public class House
    {
        public Vector PlayerPosition { get; set; }

        public int CurrentFloor { get; set; } = 1;

        public bool Brick1 { get; set; } = true;
        public bool Brick2 { get; set; } = true;

        public bool Document { get; private set; } = true;
        public readonly int RightDocumentID = 2;

        public readonly Puzzle TablePuzzle = new ();

        public bool TryTakeDocument(int documentID)
        {
            if (documentID != RightDocumentID)
                return false;
            
            Document = false;
            return true;
        }

        public class Puzzle
        {
            public bool Solved => CurrentState == WiningState;

            public bool InStartState => CurrentState == 0;

            public int CurrentState { get; private set; }

            private const int WiningState = 6;

            public void ChangeState(int nextState)
            {
                if (Solved)
                    return;

                if (CurrentState == nextState - 1)
                    CurrentState++;
                else
                    CurrentState = 0;
            }
        }
    }
}