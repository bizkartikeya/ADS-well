using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("WELL_PROPERTY")]
    public class WellProperty
    {
        public WellProperty()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WellStringPropertyId { get; set; }

        public int WellId { get; set; }
        public virtual Well Well { get; set; }


        public string Parameter { get; set; }

        [ForeignKey("Parameter")]
        public virtual WellPropertyLookup V_Parameter { get; set; }

        public string Value { get; set; }

    }
}
