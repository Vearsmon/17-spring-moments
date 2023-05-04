using UnityEngine;

namespace Model
{
    public class House
    {
        public Vector3 PlayerPosition { get; set; }

        public int CurrentFloor { get; set; } = 1;

        public bool Brick1 { get; set; } = true;
        public bool Brick2 { get; set; } = true;
    }
}