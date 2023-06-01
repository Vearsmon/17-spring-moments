using System;
using Items;
using Items.Inventory;
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

        public AudioSource audio;
        public AudioClip doorSound;

        private void FixedUpdate()
        {
            if (!Input.GetKeyDown(KeyCode.E) || playerGameObject == null)
                return;
            
            audio.PlayOneShot(doorSound);
            Core.PlayerState.items = playerGameObject.GetComponent<Inventory>().Items;
            Core.BalconyState.PlayerPosition = playerGameObject.transform.position;
            SceneTransition.SwitchToScene("House");
        }

        [Obsolete("Obsolete")]
        private void OnTriggerEnter2D(Collider2D col)
        {
            var player = col.GetComponent<Player.Player>();
            if (player == null) 
                return;

            playerGameObject = player.gameObject;
        }

        private void OnTriggerExit2D(Collider2D _)
        {
            playerGameObject = null;
        }
    }
}