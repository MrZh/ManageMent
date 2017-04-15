namespace Yang.Management.Entity.DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AttendanceLog")]
    public partial class AttendanceLog
    {
        [StringLength(50)]
        public string Id { get; set; }

        public DateTime? AttendanceTime { get; set; }

        [StringLength(50)]
        public string UserId { get; set; }

        public int? AttendanceType { get; set; }

        public int? IsDayOff { get; set; }

        [StringLength(255)]
        public string AttendanceIp { get; set; }
    }
}
