using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene.HousePuzzle
{
    public class PuzzleHouseSceneChanger : MonoBehaviour
    {
        public AudioClip exitTableSceneSound;
        public AudioSource audio;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneTransition.SwitchToScene("House");
                audio.PlayOneShot(exitTableSceneSound);
            }
                
        }
    }
}
