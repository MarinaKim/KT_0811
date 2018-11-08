namespace KT_0811
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class dic_Pavilion
    {
        [Key]
        public int PavilionId { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
    }
}
