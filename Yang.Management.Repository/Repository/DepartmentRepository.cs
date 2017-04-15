using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public DataContext context = new DataContext();
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<ListDepartmentEntity> GetAllList()
        {
            return this.context.Department.Select(c => new ListDepartmentEntity { Name = c.Name, Id = c.Id }).ToList();
        }

        public void Save(Department entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.Department.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new Department();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.Department.Add(dbclass);
            }

            dbclass.CreateTime = entity.CreateTime == null ? dbclass.CreateTime : entity.CreateTime;
            dbclass.CreateUserId = entity.CreateUserId == null ? dbclass.CreateUserId : entity.CreateUserId;
            dbclass.Name = entity.Name == null ? dbclass.Name : entity.Name;
            dbclass.Description = entity.Description == null ? dbclass.Description : entity.Description;
            dbclass.ParentDepartmentId = entity.ParentDepartmentId == null ? dbclass.ParentDepartmentId : entity.ParentDepartmentId;
            dbclass.Responsibility = entity.Responsibility == null ? dbclass.Responsibility : entity.Responsibility;

            this.context.SaveChanges();
        }
    }
}
