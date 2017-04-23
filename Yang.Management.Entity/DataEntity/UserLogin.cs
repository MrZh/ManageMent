namespace Yang.Management.Entity.DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserLogin")]
    public partial class UserLogin
    {
        [StringLength(50)]
        public string Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string RealName { get; set; }

        [StringLength(255)]
        public string PassWord { get; set; }

        [StringLength(255)]
        public string UserId { get; set; }
    }
}
