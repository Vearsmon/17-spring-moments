using System;
using System.Linq;
using Items.Picker;
using UnityEngine;

namespace Items.PickDetector
{
    public class RadiusPickDetector : MonoBehaviour, IPickDetector
    {
        [SerializeField] private float radius = 1;
        private IPicker pickerEntered;
        private bool isEntered;
        
        public event Action<IPicker> Picked;

        private void FixedUpdate()
        {
            CheckPicker();
            
            if (Input.GetKey(KeyCode.E) && isEntered)
                Picked?.Invoke(pickerEntered);
        }

        private void CheckPicker()
        {
            isEntered = false;
            foreach (var col in Physics2D.OverlapCircleAll(transform.position, radius))
                if (col.gameObject.TryGetComponent<IPicker>(out pickerEntered))
                {
                    isEntered = true;
                    break;
                }
        }
    }
}