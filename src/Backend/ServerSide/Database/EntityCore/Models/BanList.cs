using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide.Database.EntityCore.Models
{
    internal class BanList
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("type_blocking")]
        public TypeOfBlocking TypeOfBlocking { get; set; }
        [Column("player_id")]
        public int PlayerId { get; set; }
        [Column("admin_id")]
        public int AdminId { get; set; }
        [Column("reason")]
        public string Reason { get; set; }
        [Column("start_date_time")]
        public DateTime StartDateTime { get; set; }
        [Column("end_date_time")]
        public DateTime EndDateTime { get; set; }
        
    }

    internal enum TypeOfBlocking
    {
        Character,
        Account
    }

}
