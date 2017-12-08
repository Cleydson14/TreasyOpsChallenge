using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreasyOps.Models
{
    [Table("deals_updates")]
    public class DealUpdate
    {
        [Key]
        [Column("update_id")]
        public int ID { get; set; }
        
        [Column("deal_id")]
        public string Deal_ID { get; set; }

        [Column("stage_from")]
        public string StageFrom { get; set; }

        [Column("stage_to")]
        public string StageTo { get; set; }

        [Column("update_date")]
        public DateTime UpdateDate { get; set; }

        [Column("user_name")]
        public DateTime UserName { get; set; }

        [Column("pipeline_name")]
        public DateTime PipelineName { get; set; }

        [Column("stage_id_from")]
        public int StageIdFrom { get; set; }

        [Column("stage_id_to")]
        public int StageIdTo { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }
    }
}