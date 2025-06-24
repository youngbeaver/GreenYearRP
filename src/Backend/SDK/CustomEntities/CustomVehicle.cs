using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;

namespace SDK.CustomEntities
{
    public class CustomVehicle : Vehicle
    {
        public CustomVehicle(NetHandle handle) : base(handle) { }
    }
}
