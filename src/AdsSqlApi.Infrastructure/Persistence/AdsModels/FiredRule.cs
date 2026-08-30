using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("FIRED_RULE")]
    public class FiredRule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FiredRuleId { get; set; }

        public string RuleName { get; set; }

        public int? WellTestId { get; set; }
        [ForeignKey("WellTestId")]
        public virtual WellTest WELL_TEST { get; set; }

        public virtual ICollection<FiredRuleResult> FiredRuleResults { get; set; }

    }
}
