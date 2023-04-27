using System;
using Items.PickDetector;
using Items.Picker;
using Unity.VisualScripting;
using UnityEngine;

namespace Items
{
    public class PickableItem : MonoBehaviour, IItem, IPickable
    {
        public string Name => name;
        public IPickDetector PickDetector { get; private set; }

        [SerializeField] private new string name;

        private void Start()
        {
            PickDetector = gameObject.GetComponent<CommonPickDetector>() 
                           ?? gameObject.AddComponent<CommonPickDetector>();
            PickDetector.Picked += Picked;
        }

        protected virtual void Picked(IPicker picker) => picker.Pick(this);
    }
}