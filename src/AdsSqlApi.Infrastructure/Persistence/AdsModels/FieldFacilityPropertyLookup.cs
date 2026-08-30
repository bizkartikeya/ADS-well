using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("V_FIELD_FACILITY_PROPERTY")]
    public class FieldFacilityPropertyLookup
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Parameter { get; set; }

        public string Description { get; set; }

    }
}
