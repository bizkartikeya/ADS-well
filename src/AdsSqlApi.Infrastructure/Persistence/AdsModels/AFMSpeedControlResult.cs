namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("AFM_SPEED_CONTROL")]
    public partial class AFMSpeedControlResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ResultId { get; set; }

        [StringLength(50)]
        public string PadName { get; set; }

        [StringLength(50)]
        public string WellName { get; set; }
        public int WellId { get; set; }

        [StringLength(50)]
        public string NodeID { get; set; }

        public DateTimeOffset? CardDate { get; set; }

        [StringLength(100)]
        public string RecommendationCode { get; set; }

        [StringLength(2000)]
        public string AlarmHighlight { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public bool? IsOPT { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsTriggered { get; set; } 

        public bool? IsSnoozed { get; set; }

        public double? SnoozeDaysLeft { get; set; }

        public DateTimeOffset? FeedbackDate { get; set; }

        public int? FeedbackTypeId { get; set; }


    }
}
