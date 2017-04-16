namespace Yang.Management.Entity.DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resign")]
    public partial class Resign
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string CreateUserId { get; set; }

        public string Responsibility { get; set; }
    }
}
