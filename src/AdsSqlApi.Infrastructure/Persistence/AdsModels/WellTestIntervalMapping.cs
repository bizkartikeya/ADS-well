using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("WELL_TEST_INTERVAL_MAPPING")]
    public class WellTestIntervalMapping
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 1)] 
        public int WellTestId { get; set; }
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(Order = 2)] 
        public int IntervalWorkflowId { get; set; }
        public virtual IntervalWorkflow IntervalWorkflow { get; set; }
    }
}
