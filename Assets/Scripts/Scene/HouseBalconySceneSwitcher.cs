using System;
using Items;
using Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class HouseBalconySceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        
        
        [Obsolete("Obsolete")]
        private void OnTriggerEnter2D(Collider2D col)
        {
            var player = col.GetComponent<Player>();
            if (player == null) 
                return;

            var playerGameObject = player.gameObject;
            Core.PlayerState.items = playerGameObject.GetComponent<Inventory>().Items;
            Core.HouseState.PlayerPosition = new Vector3(0, 6, 0);
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            SceneManager.LoadScene(sceneName);
        }
    }
}
