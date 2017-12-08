using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreasyOps.Models
{
    [Table("deals")]
    public class Deal
    {
        [Key]
        [Column("deal_id")]
        public string ID { get; set; }

        [Column("user_name")]
        public string UserName { get; set; }        
    }
}