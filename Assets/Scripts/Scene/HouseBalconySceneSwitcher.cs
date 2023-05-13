using System;
using Items;
using JetBrains.Annotations;
using Model;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scene
{
    public class HouseBalconySceneSwitcher : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [CanBeNull] private GameObject playerGameObject;

        private bool isEntered;

        private void FixedUpdate()
        {
            if (!Input.GetKey(KeyCode.E) || !isEntered)
                return;
            
            Core.PlayerState.items = playerGameObject.GetComponent<Inventory>().Items;
            Core.HouseState.PlayerPosition = playerGameObject.transform.position;
            SceneManager.UnloadScene(SceneManager.GetActiveScene());
            SceneManager.LoadScene(sceneName);
        }

        [Obsolete("Obsolete")]
        private void OnTriggerEnter2D(Collider2D col)
        {
            var player = col.GetComponent<Player>();
            if (player == null) 
                return;

            isEntered = true;
            playerGameObject = player.gameObject;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            isEntered = false;
        }
    }
}
