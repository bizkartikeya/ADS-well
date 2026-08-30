using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("FIRED_RULE_RESULT")]
    public class FiredRuleResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FiredRuleResultId { get; set; }
        public int FiredRuleId { get; set; }
        public FiredRule FiredRule { get; set; }
        public string Parameter { get; set; }
        [ForeignKey("Parameter")]
        public virtual FiredRuleResultLookup V_Parameter { get; set; }
        public double? Value { get; set; }

    }
}
