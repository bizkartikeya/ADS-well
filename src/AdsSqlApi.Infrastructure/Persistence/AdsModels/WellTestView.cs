namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("WellTestView")]
    public partial class WellTestView
    {
        [StringLength(250)]
        public string FieldName { get; set; }

        [StringLength(100)]
        public string PadName { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string WellName { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PadId { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WellId { get; set; }

        [StringLength(200)]
        public string PadType { get; set; }

        [StringLength(200)]
        public string Rov { get; set; }

        [StringLength(200)]
        public string Port { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(7)]
        public string WellTestType { get; set; }

        public bool? IsWellActive { get; set; }

        public bool? IsPadWTVActive { get; set; }

        public bool? IsPadAutoPODSActive { get; set; }

        public bool? IsPadInferredDailyActive { get; set; }

        public bool? IsPadOperateByPriorityActive { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WellTestId { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public DateTime? CreateDate { get; set; }  //This is actually a Utc Time
    }
}
