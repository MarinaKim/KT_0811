namespace KT_0811
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dic_Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusId { get; set; }

        [Required]
        [StringLength(500)]
        public string NameEn { get; set; }

        [Required]
        [StringLength(500)]
        public string NameRu { get; set; }

        public int? StatusTypeId { get; set; }
    }
}
