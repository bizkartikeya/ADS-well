using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("FIELD")]
    public class Field
    {
        public Field()
        {
            PADS = new HashSet<FieldFacility>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FieldId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<FieldFacility> PADS { get; set; } 
    }
}
