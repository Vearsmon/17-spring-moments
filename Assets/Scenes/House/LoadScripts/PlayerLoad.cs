using Items.Inventory;
using Model;
using UnityEngine;
using UnityEngine.Events;

namespace Scenes.House.LoadScripts
{
    public class PlayerLoad : MonoBehaviour
    {
        private static int loadCount = 0;

        [SerializeField] private UnityEvent<string> firstLoad;
        
        void Start()
        {
            if (loadCount++ == 0)
                firstLoad.Invoke("Штирлиц прибыл в Берлин со спецзаданием: " +
                                 "сорвать переговоры Третьего Рейха с союзниками. " +
                                 "Штирлиц направился в офис Мюллера с целью выкрасть " +
                                 "ценные документы, дабы саботировать переговоры.");
            
            gameObject.transform.position = Core.HouseState.PlayerPosition;
            gameObject.GetComponent<Inventory>().Items = Core.PlayerState.items;
        }
    }
}
