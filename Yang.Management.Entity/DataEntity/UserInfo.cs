namespace Yang.Management.Entity.DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInfo")]
    public partial class UserInfo
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string LoginName { get; set; }

        public DateTime? Birthday { get; set; }

        [Column("IdentificationCard ")]
        [StringLength(255)]
        public string IdentificationCard { get; set; }

        public DateTime? EntryTime { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string NativePlace { get; set; }

        [StringLength(255)]
        public string Resign { get; set; }

        [StringLength(50)]
        public string DepartmentId { get; set; }

        public int? Sex { get; set; }

        public int? IsMarried { get; set; }

        [StringLength(255)]
        public string MobilePhone { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(50)]
        public string CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? Status { get; set; }

        [StringLength(255)]
        public string Password { get; set; }
    }
}
