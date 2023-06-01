using Items.Inventory;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class HousePuzzleSceneChanger : MonoBehaviour
    {
        public void Change(GameObject obj)
        {
            Core.PlayerState.items = obj.GetComponent<Inventory>().Items;
            Core.HouseState.PlayerPosition = obj.transform.position;
            SceneTransition.SwitchToScene("PuzzleScene");
        }
    }
}
