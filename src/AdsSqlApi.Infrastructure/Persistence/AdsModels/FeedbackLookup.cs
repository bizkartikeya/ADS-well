namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("V_FEEDBACK")]
    public partial class FeedbackLookup
    {
        [Key]
        public int TypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        [Required]
        [StringLength(1000)]
        public string Feedback { get; set; }

        [Required]
        [StringLength(200)]
        public string Action { get; set; }

        public double? ActionValueNumeric { get; set; }

        [StringLength(4000)]
        public string ActionValueString { get; set; }

        public bool IsActive { get; set; }

        public string Remark { get; set; }

        public DateTimeOffset CreatedDate { get; set; }
    }
}
