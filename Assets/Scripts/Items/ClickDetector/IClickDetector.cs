using System;
using UnityEngine;

namespace Items.ClickDetector
{
    public interface IClickDetector
    {
        public event Action Clicked;
    }
}