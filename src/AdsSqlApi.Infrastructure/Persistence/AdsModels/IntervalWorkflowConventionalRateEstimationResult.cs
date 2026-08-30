namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("CONVENTIONAL_RATE_ESTIMATION_RESULT")]
    public partial class IntervalWorkflowConventionalRateEstimationResult
    {
        [Key]
        public int IntervalWorkflowResultId { get; set; }

        public int IntervalWorkflowId { get; set; }
        public double? QtPred { get; set; }
        public double? QtPred_P10 { get; set; }
        public double? QtPred_P90 { get; set; }
        public double? WC { get; set; }
        public int? PercentageUncertainty { get; set; }
        public double? FinalQt { get; set; }
        [StringLength(1000)]
        public string Quality { get; set; }
        [StringLength(2000)]
        public string DQCHighlight { get; set; }
        public virtual IntervalWorkflow IntervalWorkflow { get; set; }
    }
}
