using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("WellInfo")]
    public partial class WellInfo
    {
        [StringLength(250)]
        public string FieldName { get; set; }

        [StringLength(100)]
        public string PadName { get; set; }

        [StringLength(50)]
        public string WellName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PadId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WellId { get; set; }

        [StringLength(200)]
        public string PadType { get; set; }

        [StringLength(200)]
        public string Rov { get; set; }

        [StringLength(200)]
        public string Port { get; set; }

        [StringLength(7)]
        public string WellTestType { get; set; }

        public bool? IsPadWTVActive { get; set; }

        public bool? IsPadAutoPODSActive { get; set; }

        public bool? IsPadInferredDailyActive { get; set; }

        public bool? IsPadOperateByPriorityActive { get; set; }

        public bool? IsWellActive { get; set; }

        public bool? IsWellPseudo { get; set; }
    }
}
