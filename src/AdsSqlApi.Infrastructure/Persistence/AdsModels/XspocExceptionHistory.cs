using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("XSPOC_EXCEPTION_HISTORY")]
    public partial class XspocExceptionHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HistoryId { get; set; }

        [StringLength(50)]
        public string NodeID { get; set; }

        [Required]
        [StringLength(50)]
        public string GroupName { get; set; }

        public int? Priority { get; set; }

        public DateTimeOffset Date { get; set; }

        public int? ADSWellId { get; set; }
    }
}
