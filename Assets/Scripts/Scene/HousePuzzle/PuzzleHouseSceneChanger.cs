using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene.HousePuzzle
{
    public class PuzzleHouseSceneChanger : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
                SceneManager.LoadScene("House");
        }
    }
}
