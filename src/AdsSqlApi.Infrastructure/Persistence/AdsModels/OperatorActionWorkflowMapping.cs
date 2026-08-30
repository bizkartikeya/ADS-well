using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("OPERATOR_ACTION_WORKFLOW_MAPPING")]
    public class OperatorActionWorkflowMapping
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OperatorActionId { get; set; }
        [ForeignKey("OperatorActionId")]
        public virtual OperatorAction OperatorAction { get; set; }

        public int WorkflowTypeId { get; set; }

        public string WorkflowType { get; set; }
    }
}
