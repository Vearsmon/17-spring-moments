using System;
using Items;
using JetBrains.Annotations;
using Model;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class BalconyHouseSceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [CanBeNull] private GameObject playerGameObject;

        private void FixedUpdate()
        {
            if (!Input.GetKey(KeyCode.E) || playerGameObject == null)
                return;
            
            Core.PlayerState.items = playerGameObject.GetComponent<Inventory>().Items;
            Core.BalconyState.PlayerPosition = playerGameObject.transform.position;
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            SceneManager.LoadScene(sceneName);
        }

        [Obsolete("Obsolete")]
        private void OnTriggerEnter2D(Collider2D col)
        {
            var player = col.GetComponent<Player>();
            if (player == null) 
                return;

            playerGameObject = player.gameObject;
        }

        private void OnTriggerExit(Collider other)
        {
            playerGameObject = null;
        }
    }
}