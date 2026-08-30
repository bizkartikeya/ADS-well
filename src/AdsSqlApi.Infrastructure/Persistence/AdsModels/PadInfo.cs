using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("PadInfo")]
    public partial class PadInfo
    {
        [StringLength(250)]
        public string FieldName { get; set; }

        [StringLength(100)]
        public string PadName { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PadId { get; set; }

        [StringLength(200)]
        public string PadType { get; set; }

        public bool? IsPadWTVActive { get; set; }

        public bool? IsPadAutoPODSActive { get; set; }

        public bool? IsPadInferredDailyActive { get; set; }

        public bool? IsPadOperateByPriorityActive { get; set; }
    }
}
