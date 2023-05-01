using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class SceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        public Vector3 position;
        public VectorValue playerStorage;
        public float floorAlpha;
        private void OnTriggerEnter2D(Collider2D col)
        {
            var player = col.GetComponent<Player>();
            if (player == null) 
                return;
            playerStorage.initialValue = position;
            playerStorage.floorAlpha = floorAlpha;
            SceneManager.LoadScene(sceneName);
            SceneManager.MoveGameObjectToScene(col.gameObject, SceneManager.GetSceneByName(sceneName));
        }
    }
}
