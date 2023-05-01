using System;
using Items.Picker;

namespace Items.PickDetector
{
    public interface IPickDetector
    {
        public event Action<IPicker> Picked;
    }
}