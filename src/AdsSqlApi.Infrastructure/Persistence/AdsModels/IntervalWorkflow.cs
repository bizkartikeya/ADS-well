using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("INTERVAL_WORKFLOW")]
    public class IntervalWorkflow
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IntervalWorkflowId { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkflowType { get; set; }

        public DateTimeOffset? Date { get; set; }

        public int WellId { get; set; }

        public virtual Well Well { get; set; }

        public DateTimeOffset? CreateDate { get; set; }

        public virtual ICollection<IntervalWorkflowNumericResult> NumericResults { get; set; }

        public virtual ICollection<IntervalWorkflowStringResult> StringResults { get; set; }

        public virtual ICollection<IntervalWorkflowAutoPODSRecommendationResult> RecommendationResults { get; set; }

        public virtual ICollection<IntervalWorkflowAutoPODSUpliftPredictResult> UpliftPredictResults { get; set; }

        public virtual ICollection<IntervalWorkflowPumpcardPredictResult> IntervalWorkflowPumpcardPredictResults { get; set; }
    }
}
