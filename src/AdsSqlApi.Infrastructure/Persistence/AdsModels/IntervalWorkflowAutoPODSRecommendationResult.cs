namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("AUTOPODS_RECOMMENDATION_RESULT")]
    public partial class IntervalWorkflowAutoPODSRecommendationResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntervalWorkflowResultId { get; set; }

        public int IntervalWorkflowId { get; set; }

        [StringLength(2000)]
        public string ActionCode { get; set; }

        [StringLength(2000)]
        public string ActionCodeDetail { get; set; }

        [StringLength(2000)]
        public string ActionDetail { get; set; }

        [StringLength(2000)]
        public string AlarmDetail { get; set; }

        public int? ActionCodePriority { get; set; }

        public int? ActionCodeInGroupPriority { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsTriggered { get; set; }

        public bool? IsSnoozed { get; set; }

        public double? SnoozeDaysLeft { get; set; }

        public DateTimeOffset? FeedbackDate { get; set; }

        public int? FeedbackTypeId { get; set; }
        
        [StringLength(2000)]
        public string AlarmHighlight { get; set; }

        public virtual IntervalWorkflow IntervalWorkflow { get; set; }
    }
}
