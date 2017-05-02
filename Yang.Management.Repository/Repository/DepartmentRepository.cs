using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity;
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

        public int Delete(string[] ids)
        {
            int users = this.context.UserInfo.Where(c => ids.Contains(c.DepartmentId)).Count();
            int department = this.context.Department.Where(c => ids.Contains(c.ParentDepartmentId)).Count();
           

            if (users != 0 || department != 0)
            {
                return 0;
            }
            List<Department> list = this.context.Department.Where(c => ids.Any(b => b.Equals(c.Id))).ToList();
            this.context.Department.RemoveRange(list);
            this.context.SaveChanges();
            return 1;
        }

        public List<ListDepartmentEntity> GetAllList()
        {
            return this.context.Department.Select(c => new ListDepartmentEntity { Name = c.Name, Id = c.Id }).ToList();
        }

        public Department GetItem(string id)
        {
            return this.context.Department.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public ListEntity<ListDepartmentEntity> GetList(string key, int pageIndex, int pageSize)
        {
            List<ListDepartmentEntity> list = new List<ListDepartmentEntity>();
            int total = this.context.Department.Where(c => c.Name.Contains(key)).Count();
            if (total <= 0)
            {
                return new ListEntity<ListDepartmentEntity>(list, total, pageIndex, pageSize);
            }
            List<string> ids = this.context.Department.Where(c => c.Name.Contains(key)).OrderBy(c => c.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(c=>c.Id).ToList();
            BaseQuery query = new BaseQuery("SELECT Id,Name,Description,CreateTime,(SELECT Name FROM Department where Id=de.ParentDepartmentId ) as ParentDepartmentName FROM Department as de where id in @ids", new { ids = ids });
            list= DapperContext.BaseGetListByParam<ListDepartmentEntity>(query);
            return new ListEntity<ListDepartmentEntity>(list, total, pageIndex, pageSize);
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
