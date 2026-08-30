using AdsSqlApi.Infrastructure.Persistence.AdsModels.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("WELL_TEST_STRING_RESULT")]
    public class WellTestStringResult : IStringResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WellTestResultId { get; set; }

        public int WellTestId { get; set; }
        [ForeignKey("WellTestId")]
        public virtual WellTest WellTest { get; set; }
        public string Parameter { get; set; }
        [ForeignKey("Parameter")]
        public virtual WorkflowResultLookup V_Parameter { get; set; }
        public string Value { get; set; }
    }
}
