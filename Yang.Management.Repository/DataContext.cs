namespace Yang.Management.Repository
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Yang.Management.Entity.DataEntity;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<AttendanceLog> AttendanceLog { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<DimissionRecord> DimissionRecord { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<SalaryModifyLog> SalaryModifyLog { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserModifyLog> UserModifyLog { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttendanceLog>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceLog>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceLog>()
                .Property(e => e.AttendanceIp)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.ParentDepartmentId)
                .IsUnicode(false);

            modelBuilder.Entity<DimissionRecord>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<DimissionRecord>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<DimissionRecord>()
                .Property(e => e.DepartmentId)
                .IsUnicode(false);

            modelBuilder.Entity<DimissionRecord>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);

            modelBuilder.Entity<DimissionRecord>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.Contents)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);

            modelBuilder.Entity<News>()
                .Property(e => e.NewsTypeId)
                .IsUnicode(false);

            modelBuilder.Entity<SalaryModifyLog>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<SalaryModifyLog>()
                .Property(e => e.UserId)
                .IsUnicode(false);

            modelBuilder.Entity<SalaryModifyLog>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);

            modelBuilder.Entity<SalaryModifyLog>()
                .Property(e => e.SalaryModify)
                .HasPrecision(11, 0);

            modelBuilder.Entity<SalaryModifyLog>()
                .Property(e => e.Content)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.LoginName)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.IdentificationCard_)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.NativePlace)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Resign)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.DepartmentId)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.MobilePhone)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);

            modelBuilder.Entity<UserInfo>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.RealName)
                .IsUnicode(false);

            modelBuilder.Entity<UserLogin>()
                .Property(e => e.PassWord)
                .IsUnicode(false);

            modelBuilder.Entity<UserModifyLog>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<UserModifyLog>()
                .Property(e => e.OrginalDepartmentId)
                .IsUnicode(false);

            modelBuilder.Entity<UserModifyLog>()
                .Property(e => e.NowDepartmentId)
                .IsUnicode(false);

            modelBuilder.Entity<UserModifyLog>()
                .Property(e => e.OriginalResign)
                .IsUnicode(false);

            modelBuilder.Entity<UserModifyLog>()
                .Property(e => e.NowResign)
                .IsUnicode(false);

            modelBuilder.Entity<UserModifyLog>()
                .Property(e => e.ModifyUserId)
                .IsUnicode(false);

            modelBuilder.Entity<UserModifyLog>()
                .Property(e => e.CreateUserId)
                .IsUnicode(false);
        }
    }
}
