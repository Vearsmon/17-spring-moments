using System;
using System.IO;
using Newtonsoft.Json;

// Для того чтобы record работал корректно
namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit {}
}

namespace Model
{
    public static class Core
    {
        public static House HouseState { get; private set; } = new();
        public static Balcony BalconyState { get; private set; }= new();

        public static PlayerState PlayerState { get; private set; }= new();

        public static bool TrySave()
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(new CoreData(HouseState, BalconyState, PlayerState));
                
                var sw = new StreamWriter("save", true);
                sw.Write(serialized);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to save");
                Console.WriteLine(e.Message);
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
        
        private record CoreData(House House, Balcony Balcony, PlayerState PlayerState);
    }
}