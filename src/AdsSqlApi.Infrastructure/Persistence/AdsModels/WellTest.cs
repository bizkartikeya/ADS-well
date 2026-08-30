using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("WELL_TEST")]
    public class WellTest
    {
        public WellTest()
        {
            FIRED_RULES = new HashSet<FiredRule>();
        }

        public WellTest(int id, DateTimeOffset? start, int? wellName, string padName)
        {
            WellTestId = id;
            StartDate = start;
            WELL = new Well();
            WELL.WellName = wellName.ToString();
            WELL.FieldFacility = new FieldFacility();
            WELL.FieldFacility.Name = padName;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WellTestId { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public string WorkflowType { get; set; }

        public DateTime? CreateDate { get; set; }

        public virtual ICollection<FiredRule> FIRED_RULES { get; set; }

        public int WellId { get; set; }
        public virtual Well WELL { get; set; }

        public virtual ICollection<WellTestNumericResult> NumericResults { get; set; }
        public virtual ICollection<WellTestStringResult> StringResults { get; set; } 
    }
}
