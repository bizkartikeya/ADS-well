namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("AUTOPODS_UPLIFT_PREDICT_RESULT")]
    public partial class IntervalWorkflowAutoPODSUpliftPredictResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntervalWorkflowResultId { get; set; }

        public int IntervalWorkflowId { get; set; }
        public double? QtPred { get; set; }

        public double? DeltaQtPred { get; set; }

        public double? DeltaQtPred_P10 { get; set; }

        public double? DeltaQtPred_P90 { get; set; }

        public double? DeltaQtPredPC { get; set; }

        public double? DeltaQtPredPC_P10 { get; set; }

        public double? DeltaQtPredPC_P90 { get; set; }

        public double? DeltaSD { get; set; }

        public double? DeltaQtPredSD { get; set; }

        public double? DeltaQtPredSD_P10 { get; set; }

        public double? DeltaQtPredSD_P90 { get; set; }

        public double? DeltaSU { get; set; }

        public double? DeltaQtPredSU { get; set; }

        public double? DeltaQtPredSU_P10 { get; set; }

        public double? DeltaQtPredSU_P90 { get; set; }

        public double? DeltaCP { get; set; }

        public double? DeltaQtPredVW { get; set; }

        public double? DeltaQtPredVW_P10 { get; set; }

        public double? DeltaQtPredVW_P90 { get; set; }

        public double? WC { get; set; }

        public double? DeltaQtPredSC { get; set; }

        public double? DeltaQtPredSC_P10 { get; set; }

        public double? DeltaQtPredSC_P90 { get; set; }

        public double? DeltaQtPredACID { get; set; }

        public double? DeltaQtPredACID_P10 { get; set; }

        public double? DeltaQtPredACID_P90 { get; set; }

        public double? DeltaQtPredPumpFix { get; set; }

        public double? DeltaQtPredPumpFix_P10 { get; set; }

        public double? DeltaQtPredPumpFix_P90 { get; set; }
        [StringLength(2000)]
        public string DQCHighlight { get; set; }

        public virtual IntervalWorkflow IntervalWorkflow { get; set; }
    }
}
