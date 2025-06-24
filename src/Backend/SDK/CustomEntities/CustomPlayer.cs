using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTANetworkAPI;
using SDK.Accounts;

namespace SDK.CustomEntities
{
    public class CustomPlayer : Player
    {
        public int Id { get; set; }
        public Character Character { get; set; }
        public Account Account { get; set; }

        public CustomPlayer(NetHandle handle) : base(handle) {}
    }
}
