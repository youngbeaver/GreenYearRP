using System.Security.Cryptography;
using System.Text;
using GTANetworkAPI;
using SDK.CustomEntities;
using ServerSide.Database.EntityCore;
namespace ServerSide
{
    public class Main : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            RAGE.Entities.Players.CreateEntity = (NetHandle handle) => new CustomPlayer(handle);
            RAGE.Entities.Vehicles.CreateEntity = (NetHandle handle) => new CustomVehicle(handle);
        }
    }
}
