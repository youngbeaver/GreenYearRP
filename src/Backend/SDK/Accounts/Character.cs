using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Accounts
{
    public class Character
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        [Column("nickname")]
        public int Nickname { get; set; }
        [Column("exp")]
        public int Exp { get; set; }
        [Column("money")]
        public int Money { get; set; }
        [Column("bank_money")]
        public int BankMoney { get; set; }
    }
}
