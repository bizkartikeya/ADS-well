using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("OPERATOR_ACTION")]
    public class OperatorAction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OperatorActionId { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1)]
        public string Action { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        public DateTimeOffset? CreateDate { get; set; }

    }
}
