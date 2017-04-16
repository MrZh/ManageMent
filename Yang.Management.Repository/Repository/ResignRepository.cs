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
    public class ResignRepository : IResignRepository
    {
        public DataContext context = new DataContext();
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public int Delete(string[] ids)
        {
            int users = this.context.UserInfo.Where(c => ids.Contains(c.Resign)).Count();

            if (users != 0)
            {
                return 0;
            }
            List<Resign> list = this.context.Resign.Where(c => ids.Any(b => b.Equals(c.Id))).ToList();
            this.context.Resign.RemoveRange(list);
            this.context.SaveChanges();
            return 1;
        }

        public List<ListResignEntity> GetAllList()
        {
            return this.context.Resign.Select(c => new ListResignEntity { Name = c.Name, Id = c.Id }).ToList();
        }

        public Resign GetItem(string id)
        {
            return this.context.Resign.Where(c => c.Id.Equals(id)).FirstOrDefault();
        }

        public ListEntity<ListResignEntity> GetList(string key, int pageIndex, int pageSize)
        {
            List<ListResignEntity> list = new List<ListResignEntity>();
            int total = this.context.Resign.Where(c => c.Name.Contains(key)).Count();
            if (total <= 0)
            {
                return new ListEntity<ListResignEntity>(list, total, pageIndex, pageSize);
            }
            List<string> ids = this.context.Resign.Where(c => c.Name.Contains(key)).OrderBy(c => c.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(c => c.Id).ToList();
            BaseQuery query = new BaseQuery("SELECT Id,Name,Description,CreateTime,Responsibility FROM Resign as de where id in @ids", new { ids = ids });
            list = DapperContext.BaseGetListByParam<ListResignEntity>(query);
            return new ListEntity<ListResignEntity>(list, total, pageIndex, pageSize);
        }

        public void Save(Resign entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.Resign.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new Resign();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.Resign.Add(dbclass);
            }

            dbclass.CreateTime = entity.CreateTime == null ? dbclass.CreateTime : entity.CreateTime;
            dbclass.CreateUserId = entity.CreateUserId == null ? dbclass.CreateUserId : entity.CreateUserId;
            dbclass.Name = entity.Name == null ? dbclass.Name : entity.Name;
            dbclass.Description = entity.Description == null ? dbclass.Description : entity.Description;
            dbclass.Responsibility = entity.Responsibility == null ? dbclass.Responsibility : entity.Responsibility;

            this.context.SaveChanges();
        }
    }
}
