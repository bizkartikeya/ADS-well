namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("PUMPCARD_PREDICTION_RESULT")]
    public partial class IntervalWorkflowPumpcardPredictResult
    {
        [Key]
        public int IntervalWorkflowResultId { get; set; }

        public int IntervalWorkflowId { get; set; }

        [Required]
        [StringLength(50)]
        public string NodeID { get; set; }

        [Required]
        [StringLength(50)]
        public string DownholeCardPrediction { get; set; }

        public double PredictionProbability { get; set; }

        public double? PredictedFillage { get; set; }

        public double? PredictedFillbase { get; set; }
        public double? PredictedFillagePos { get; set; }
        public double? PredictedFillbasePerc { get; set; }
        public double? DerivedFillagePos { get; set; }


        public virtual IntervalWorkflow IntervalWorkflow { get; set; }
    }
}
