using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

// Для того чтобы record работал корректно
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}

namespace Model
{
    public struct Vector
    {
        public float x;
        public float y;
        public float z;

        public Vector(Vector3 vector3)
        {
            x = vector3.x;
            y = vector3.y;
            z = vector3.z;
        }
        
        public Vector3 ToVector3()
        {
            return new Vector3(x, y, z);
        }
    }
    
    public static class Core
    {
        public static string CurrentScene;
        
        public static House HouseState { get; private set; } = new();
        public static Balcony BalconyState { get; private set; }= new();

        public static PlayerState PlayerState { get; private set; }= new();

        public static void Reset()
        {
            HouseState = new House();
            BalconyState = new Balcony();

            PlayerState = new PlayerState();
        }
        
        public static bool TrySave()
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(
                    new CoreData(CurrentScene, HouseState, BalconyState, PlayerState));
                
                var sw = new StreamWriter("save", false);
                sw.Write(serialized);
                sw.Close();
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
                return false;
            }

            return true;
        }

        public static bool TryLoad()
        {
            try
            {
                var sw = new StreamReader("save");
                var serialized = sw.ReadToEnd();
                sw.Close();

                var coreData = JsonConvert.DeserializeObject<CoreData>(serialized);
                CurrentScene = coreData!.currentScene;
                HouseState = coreData!.House;
                BalconyState = coreData!.Balcony;
                PlayerState = coreData!.PlayerState;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to load");
                Console.WriteLine(e.Message);
                return false;
            }

            return true;
        }
        
        private record CoreData(string currentScene, House House, Balcony Balcony, PlayerState PlayerState);
    }
}