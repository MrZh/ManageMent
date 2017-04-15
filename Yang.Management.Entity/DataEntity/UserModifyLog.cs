namespace Yang.Management.Entity.DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserModifyLog")]
    public partial class UserModifyLog
    {
        [StringLength(50)]
        public string Id { get; set; }

        public DateTime? ModifyTime { get; set; }

        [StringLength(50)]
        public string OrginalDepartmentId { get; set; }

        [StringLength(50)]
        public string NowDepartmentId { get; set; }

        [StringLength(255)]
        public string OriginalResign { get; set; }

        [StringLength(255)]
        public string NowResign { get; set; }

        [StringLength(50)]
        public string ModifyUserId { get; set; }

        [StringLength(50)]
        public string CreateUserId { get; set; }
    }
}
