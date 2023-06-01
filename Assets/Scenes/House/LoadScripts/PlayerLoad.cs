using System;
using Items.Inventory;
using Model;
using NPCs.Storyteller;
using UnityEngine;
using UnityEngine.Events;

namespace Scenes.House.LoadScripts
{
    public class PlayerLoad : MonoBehaviour
    {
        private static int loadCount;

        [SerializeField] private UnityEvent<string> firstLoad;
        [SerializeField] private UnityEvent firstLoadClose;

        void Start()
        {
            if (loadCount++ == 0)
            {
                var storyteller = GameObject.FindGameObjectWithTag("Storyteller").GetComponent<Storyteller>();
                storyteller.ShowMessagesSequence(
                    "Мюллер скоро должен заехать за кое-каким документом в штаб.".ToUpper(),
                    "Штирлиц попал в штаб, но пока не знает о каком документе идет речь.".ToUpper(),
                    "Было бы неплохо посмотреть телефонную почту - подумал Штирлиц.".ToUpper());
            }
            
            gameObject.transform.position = Core.HouseState.PlayerPosition;
            gameObject.GetComponent<Inventory>().Items = Core.PlayerState.items;
        }
    }
}
