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
    public class DimissionRecordRepository : IDimissionRecordRepository
    {
        public DataContext context = new DataContext();

        public ListEntity<ListDimissionRecordEntity> GetListByUserId(string id, int pageIndex, int pageSize)
        {
            List<ListDimissionRecordEntity> list = new List<ListDimissionRecordEntity>();
            int total = this.context.DimissionRecord.Where(c => c.UserId==id).Count();
            if (total <= 0)
            {
                return new ListEntity<ListDimissionRecordEntity>(list, total, pageIndex, pageSize);
            }
            List<string> ids = this.context.DimissionRecord.Where(c => c.UserId == id).OrderBy(c => c.CreateTime).Skip((pageIndex - 1) * pageSize).Take(pageSize).Select(c => c.Id).ToList();

            BaseQuery query = new BaseQuery("SELECT id,UserId,CreateTime,Type,Content,(SELECT Name from UserInfo where id=UserId) as UserName, (select Name from Department where id=DepartmentId) as DepartmentName FROM DimissionRecord where id in @ids", new { ids = ids });
            list = DapperContext.BaseGetListByParam<ListDimissionRecordEntity>(query);
            return new ListEntity<ListDimissionRecordEntity>(list, total, pageIndex, pageSize);
        }

        public void Save(DimissionRecord entity)
        {

            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.DimissionRecord.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new DimissionRecord();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.DimissionRecord.Add(dbclass);
            }

            dbclass.CreateTime = entity.CreateTime == null ? dbclass.CreateTime : entity.CreateTime;
            dbclass.CreateUserId = entity.CreateUserId == null ? dbclass.CreateUserId : entity.CreateUserId;
            dbclass.UserId = entity.UserId == null ? dbclass.UserId : entity.UserId;
            dbclass.Content = entity.Content == null ? dbclass.Content : entity.Content;
            dbclass.DepartmentId = entity.DepartmentId == null ? dbclass.DepartmentId : entity.DepartmentId;
            dbclass.Type = entity.Type == null ? dbclass.Type : entity.Type;

            this.context.SaveChanges();
        }
    }
}
