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
                storyteller.ShowMessage(("Штирлиц прибыл в Берлин со спецзаданием: " +
                                         "сорвать переговоры Третьего Рейха с союзниками. " +
                                         "Штирлиц направился в офис Мюллера с целью выкрасть " +
                                         "ценные документы, дабы саботировать переговоры.").ToUpper());
            }
            
            gameObject.transform.position = Core.HouseState.PlayerPosition;
            gameObject.GetComponent<Inventory>().Items = Core.PlayerState.items;
        }
    }
}
