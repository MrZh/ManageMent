namespace Yang.Management.Entity.DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(255)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Column(TypeName = "text")]
        public string Contents { get; set; }

        public DateTime? CreateTime { get; set; }

        [StringLength(255)]
        public string CreateUserId { get; set; }

        [StringLength(255)]
        public string NewsTypeId { get; set; }
    }
}
