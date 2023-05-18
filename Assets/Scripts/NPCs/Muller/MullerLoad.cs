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
            if (!Core.HouseState.TablePuzzle.Solved)
                Destroy(gameObject);

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
