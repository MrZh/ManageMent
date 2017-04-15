namespace Yang.Management.Entity.DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DimissionRecord")]
    public partial class DimissionRecord
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string DepartmentId { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(50)]
        public string CreateUserId { get; set; }

        public int? Type { get; set; }

        [StringLength(500)]
        public string Content { get; set; }
    }
}
