using System;
using UnityEngine;

namespace Items.InteractionDetector
{
    public interface IInteractionDetector
    {
        public event Action<GameObject> Interacted;
    }
}