using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdsSqlApi.Infrastructure.Persistence.AdsModels
{
    [Table("TAG_REPOSITORY_EXPERION")]
    public partial class TagRepositoryExperion
    {
        [Key]
        [StringLength(100)]
        public string Tag { get; set; }

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

        public bool IsActive { get; set; }

        public bool IsValid { get; set; }

        [StringLength(1000)]
        public string Comment { get; set; }

        public DateTimeOffset? CommentDate { get; set; }
    }
}
