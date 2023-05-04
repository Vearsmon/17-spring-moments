using System;
using Items;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class BalconyHouseSceneSwitcher : MonoBehaviour
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
            Core.BalconyState.PlayerPosition = playerGameObject.transform.position;
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            SceneManager.LoadScene(sceneName);
        }
    }
}