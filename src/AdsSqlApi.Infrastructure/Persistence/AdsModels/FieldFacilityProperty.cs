using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("FIELD_FACILITY_PROPERTY")]
    public class FieldFacilityProperty
    {
        public FieldFacilityProperty()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FieldFacilityPropertyId { get; set; }

        public int FieldFacilityId { get; set; }
        public virtual FieldFacility FIELD_FACILITY { get; set; }

        public string Parameter { get; set; }

        [ForeignKey("Parameter")]
        public virtual FieldFacilityPropertyLookup V_Parameter { get; set; }

        public string Value { get; set; }

    }
}
