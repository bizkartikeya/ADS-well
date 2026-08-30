using AdsSqlApi.Infrastructure.Persistence.AdsModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("INTERVAL_WORKFLOW_STRING_RESULT")]
    public class IntervalWorkflowStringResult : IStringResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntervalWorkflowResultId { get; set; }

        public int IntervalWorkflowId { get; set; }
        public virtual IntervalWorkflow IntervalWorkflow { get; set; }
        public string Parameter { get; set; }
        [ForeignKey("Parameter")]
        public virtual WorkflowResultLookup V_Parameter { get; set; }
        public string Value { get; set; }
    }
}
