using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("TAG_REPOSITORY_PHD")]
    public partial class TagRepositoryPHD
    {
        [Key]
        public int TagRepositoryID { get; set; }

        [Required]
        [StringLength(200)]
        public string TagEntityType { get; set; }

        [Required]
        [StringLength(200)]
        public string TagEntityName { get; set; }

        public int? TagEntityId { get; set; }

        [Required]
        [StringLength(200)]
        public string TagName { get; set; }

        [Required]
        [StringLength(100)]
        public string Tag { get; set; }

        public bool IsTagValid { get; set; }

        [StringLength(100)]
        public string Tag1 { get; set; }

        public bool? IsTag1Valid { get; set; }

        [StringLength(100)]
        public string Tag2 { get; set; }

        public bool? IsTag2Valid { get; set; }

        [StringLength(100)]
        public string Tag3 { get; set; }

        public bool? IsTag3Valid { get; set; }

        [StringLength(100)]
        public string Tag4 { get; set; }

        public bool? IsTag4Valid { get; set; }

        [StringLength(100)]
        public string Tag5 { get; set; }

        public bool? IsTag5Valid { get; set; }

        [StringLength(100)]
        public string Tag6 { get; set; }

        public bool? IsTag6Valid { get; set; }

        [StringLength(100)]
        public string Tag7 { get; set; }

        public bool? IsTag7Valid { get; set; }

        [StringLength(100)]
        public string Tag8 { get; set; }

        public bool? IsTag8Valid { get; set; }

        [StringLength(100)]
        public string Tag9 { get; set; }

        public bool? IsTag9Valid { get; set; }

        public DateTimeOffset? ActiveThrough { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        public DateTimeOffset? CommentDate { get; set; }
    }
}
