using Model;
using UnityEngine;

namespace NPCs.Muller
{
    public class MullerLoad : MonoBehaviour
    {
        [SerializeField] private GameObject spawnPosition;
        [SerializeField] private GameObject appearedPosition;

        private void Start()
        {
            if (Core.HouseState.Document)
            {
                Destroy(gameObject);
                return;
            }
            
            GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller.Storyteller>().ShowMessage(
                "Штирлиц еще никогда не был так близок к провалу.".ToUpper());

            if (Core.BalconyState.MullerAppeared)
                gameObject.transform.position = appearedPosition.transform.position;
            else
            {
                gameObject.transform.position = spawnPosition.transform.position;
                var linearMover = gameObject.AddComponent<LinearMover>();
                linearMover.to = appearedPosition;
            }
            Core.BalconyState.MullerAppeared = true;
        }
    }
}
