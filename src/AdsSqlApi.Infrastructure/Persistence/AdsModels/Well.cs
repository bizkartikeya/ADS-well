using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("WELL")]
    public class Well
    {
        public Well()
        {
            WELL_TEST = new HashSet<WellTest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WellId { get; set; }

        [StringLength(50)]
        public string WellName { get; set; }

        public int? FieldFacilityId { get; set; }

        public virtual FieldFacility FieldFacility { get; set; }

        public virtual ICollection<WellTest> WELL_TEST { get; set; }
        public virtual ICollection<WellProperty> WELL_PROPERTY { get; set; } 
    }
}
