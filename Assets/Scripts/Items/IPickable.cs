using Items.PickDetector;
using UnityEngine;

namespace Items
{
    public interface IPickable
    {
        public IPickDetector PickDetector { get; }
    }
}