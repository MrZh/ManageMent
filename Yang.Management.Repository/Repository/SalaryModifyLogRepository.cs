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
    public class SalaryModifyLogRepository : ISalaryModifyLogRepository
    {
        public DataContext context = new DataContext();
        public ListEntity<ListSalaryModifyLogEntity> GetList(string id, int pageIndex, int pageSize)
        {
            List<ListSalaryModifyLogEntity> list = new List<ListSalaryModifyLogEntity>();
            int total = this.context.SalaryModifyLog.Where(c => c.UserId == id).Count();
            if (total <= 0)
            {
                return new ListEntity<ListSalaryModifyLogEntity>(list, total, pageIndex, pageSize);
            }
            List<string> ids = this.context.SalaryModifyLog.Where(c => c.UserId == id).OrderBy(c => c.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(c => c.Id).ToList();

            BaseQuery query = new BaseQuery("SELECT Id, UserId,CreateTime,CreateUserId,SalaryModify,OriginalSalary,Content,(SELECT Name from UserInfo where Id=UserId) as UserName FROM SalaryModifyLog where Id in @ids", new { ids = ids });
            list = DapperContext.BaseGetListByParam<ListSalaryModifyLogEntity>(query);
            return new ListEntity<ListSalaryModifyLogEntity>(list, total, pageIndex, pageSize);
        }

        public void Save(SalaryModifyLog entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.SalaryModifyLog.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new SalaryModifyLog();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.SalaryModifyLog.Add(dbclass);
            }

            dbclass.CreateTime = entity.CreateTime == null ? dbclass.CreateTime : entity.CreateTime;
            dbclass.CreateUserId = entity.CreateUserId == null ? dbclass.CreateUserId : entity.CreateUserId;
            dbclass.UserId = entity.UserId == null ? dbclass.UserId : entity.UserId;
            dbclass.Content = entity.Content == null ? dbclass.Content : entity.Content;
            dbclass.OriginalSalary = entity.OriginalSalary == null ? dbclass.OriginalSalary : entity.OriginalSalary;
            dbclass.SalaryModify = entity.SalaryModify == null ? dbclass.SalaryModify : entity.SalaryModify;

            this.context.SaveChanges();
        }
    }
}
