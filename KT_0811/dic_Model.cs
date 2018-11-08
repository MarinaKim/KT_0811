namespace KT_0811
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dic_Model
    {
        [Key]
        public int ModelId { get; set; }

        [StringLength(50)]
        public string Code { get; set; }

        [StringLength(500)]
        public string Name { get; set; }

        public int? SeriesId { get; set; }
    }
}
