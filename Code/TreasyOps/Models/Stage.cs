using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TreasyOps.Models
{
    [Table("stages")]
    public class Stage
    {
        [Key]
        [Column("stage_id")]
        public int ID { get; set; }

        [Column("stage_name")]
        public string Name { get; set; }

        [Column("pipeline_name")]
        public string PipelineName { get; set; }

        [Column("pipeline_type")]
        public string PipelineType { get; set; }
    }
}