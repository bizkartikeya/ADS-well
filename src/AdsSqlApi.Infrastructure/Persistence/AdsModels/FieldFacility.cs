using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("FIELD_FACILITY")]
    public class FieldFacility
    {
        public FieldFacility()
        {
            WELLS = new HashSet<Well>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FieldFacilityId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Well> WELLS { get; set; }

        public int? FieldId { get; set; }

        public virtual Field FIELD { get; set; }

        public virtual ICollection<FieldFacilityProperty> FIELD_FACILITY_PROPERTY { get; set; } 
    }
}
