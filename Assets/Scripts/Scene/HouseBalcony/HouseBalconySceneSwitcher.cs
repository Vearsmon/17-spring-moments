using System;
using Items;
using Items.Inventory;
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

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.E) || !isEntered)
                return;
            
            Core.PlayerState.items = playerGameObject.GetComponent<Inventory>().Items;
            Core.HouseState.PlayerPosition = new Vector(transform.position);
            SceneTransition.SwitchToScene("Balcony");
        }

        [Obsolete("Obsolete")]
        private void OnTriggerEnter2D(Collider2D col)
        {
            var player = col.GetComponent<Player.Player>();
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
