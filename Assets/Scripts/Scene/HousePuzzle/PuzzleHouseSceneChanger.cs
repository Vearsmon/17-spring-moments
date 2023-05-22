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
            if (Input.GetKey(KeyCode.Escape))
            {
                audio.PlayOneShot(exitTableSceneSound);
                SceneManager.LoadScene("House");
            }
                
        }
    }
}
