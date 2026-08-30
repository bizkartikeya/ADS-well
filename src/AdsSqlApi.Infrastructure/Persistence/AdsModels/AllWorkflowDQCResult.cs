namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("DATA_QUALITY_CHECK")]
    public partial class AllWorkflowDQCResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }

        [StringLength(50)]
        public string PadName { get; set; }

        [StringLength(50)]
        public string WellName { get; set; }

        public int WellId { get; set; }

        [StringLength(2000)]
        public string Measurement { get; set; }

        [StringLength(2000)]
        public string Parameter { get; set; }

        [StringLength(2000)]
        public string Value { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        public DateTimeOffset CreateDate { get; set; }


    }
}
