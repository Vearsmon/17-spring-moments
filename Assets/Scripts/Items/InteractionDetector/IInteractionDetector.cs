using System;
using Items.Picker;
using UnityEngine;

namespace Items.PickDetector
{
    public interface IInteractionDetector
    {
        public event Action<GameObject> Interacted;
    }
}