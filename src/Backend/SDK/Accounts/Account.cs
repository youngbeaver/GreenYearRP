using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Accounts
{
    public class Account
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("login")]
        public string Login { get; set; }
        [Column("email")]
        public string? Email { get; set; }
        [Column("donate_count")]
        public int DonateCount { get; set; }

    }
}
