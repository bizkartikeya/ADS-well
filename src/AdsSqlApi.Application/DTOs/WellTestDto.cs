using System;

namespace AdsSqlApi.Application.Dtos
{
    public class WellTestDto
    {
        public string FieldName { get; set; }
        public string PadName { get; set; }
        public string WellName { get; set; }
        public int PadId { get; set; }
        public int WellId { get; set; }
        public string PadType { get; set; }
        public string Rov { get; set; }
        public string Port { get; set; }
        public string WellTestType { get; set; }
        public bool? IsWellActive { get; set; }
        public bool? IsPadWTVActive { get; set; }
        public bool? IsPadAutoPODSActive { get; set; }
        public bool? IsPadInferredDailyActive { get; set; }
        public bool? IsPadOperateByPriorityActive { get; set; }
        public int WellTestId { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public DateTimeOffset? EndDate { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
