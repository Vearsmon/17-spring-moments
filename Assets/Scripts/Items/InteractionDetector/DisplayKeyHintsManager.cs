using UnityEngine;

namespace Items.InteractionDetector
{
    public class DisplayKeyHintsManager : MonoBehaviour
    {
        [SerializeField] private GameObject hint;

        private void Start()
        {
            hint.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            hint.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            hint.SetActive(false);
        }
    }
}
