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
    public class UserModifyLogRepository : IUserModifyLogRepository
    {
        public DataContext context = new DataContext();
        public ListEntity<ListUserModifyLogEntity> GetList(string id, int pageIndex, int pageSize)
        {
            List<ListUserModifyLogEntity> list = new List<ListUserModifyLogEntity>();
            int total = this.context.SalaryModifyLog.Where(c => c.UserId == id).Count();
            if (total <= 0)
            {
                return new ListEntity<ListUserModifyLogEntity>(list, total, pageIndex, pageSize);
            }
            List<string> ids = this.context.SalaryModifyLog.Where(c => c.UserId == id).OrderBy(c => c.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(c => c.Id).ToList();

            BaseQuery query = new BaseQuery("SELECT id,UserId,CreateTime,Type,Content,(SELECT Name from UserInfo where id=UserId) as UserName, (select Name from Department where id=DepartmentId) as DepartmentName FROM DimissionRecord where id in @ids", new { ids = ids });
            list = DapperContext.BaseGetListByParam<ListUserModifyLogEntity>(query);
            return new ListEntity<ListUserModifyLogEntity>(list, total, pageIndex, pageSize);
        }

        public void Save(UserModifyLog entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.UserModifyLog.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new UserModifyLog();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.UserModifyLog.Add(dbclass);
            }

            dbclass.ModifyTime = entity.ModifyTime == null ? dbclass.ModifyTime : entity.ModifyTime;
            dbclass.CreateUserId = entity.CreateUserId == null ? dbclass.CreateUserId : entity.CreateUserId;
            dbclass.ModifyUserId = entity.ModifyUserId == null ? dbclass.ModifyUserId : entity.ModifyUserId;
            dbclass.NowDepartmentId = entity.NowDepartmentId == null ? dbclass.NowDepartmentId : entity.NowDepartmentId;
            dbclass.NowResign = entity.NowResign == null ? dbclass.NowResign : entity.NowResign;
            dbclass.OrginalDepartmentId = entity.OrginalDepartmentId == null ? dbclass.OrginalDepartmentId : entity.OrginalDepartmentId;
            dbclass.OriginalResign = entity.OriginalResign == null ? dbclass.OriginalResign : entity.OriginalResign;

            this.context.SaveChanges();
        }
    }
}
