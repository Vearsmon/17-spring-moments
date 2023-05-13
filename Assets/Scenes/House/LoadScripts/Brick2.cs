using Items.InteractionDetector;
using Model;
using UnityEngine;

namespace Scenes.House.LoadScripts
{
    public class Brick2 : MonoBehaviour
    {
        private void Start()
        {
            gameObject.GetComponent<IInteractionDetector>().Interacted += _ => Core.HouseState.Brick2 = false;
            if (!Core.HouseState.Brick2)
                Destroy(gameObject);
        }
    }
}
