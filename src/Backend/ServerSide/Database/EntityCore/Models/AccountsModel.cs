using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SDK.Accounts;

namespace ServerSide.Database.EntityCore.Models
{
    internal class AccountsModel : Account
    {
        [Column("password")]
        public string Password { get; set; }
        [Column("ip")]
        public string IP { get; set; }
        [Column("serial")]
        public string Serial { get; set; }
        [Column("social_id")]
        public string SocialID { get; set; }

        public AccountsModel(string login, string password, string iP, string serial, string socialID)
        { 
            Login = login;
            Password = password;
            IP = iP;
            Serial = serial;
            SocialID = socialID;
        }
    }
}
