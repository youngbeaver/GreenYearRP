using GTANetworkAPI;
using ServerSide.Database.EntityCore;
using ServerSide.Database.EntityCore.Models;

namespace ServerSide
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public static void OnResourceStart()
        {
            Console.WriteLine("prot");
        }
    }
}
