using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("ADS_LOG")]
    public partial class DatabaseLog
    {
        [Key]
        public Guid ContextID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid? ParentContextID { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        public DateTimeOffset StatusTime { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset? EndTime { get; set; }

        [StringLength(2000)]
        public string Input { get; set; }

        public string Message { get; set; }
    }
}
