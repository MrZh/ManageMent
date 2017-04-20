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
    public class UserInfoRepository : IUserInfoRepository
    {

        public DataContext context = new DataContext();

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(string name)
        {
            int result = this.context.UserInfo.Where(c => c.LoginName == name).Count();
            if (result > 0)
            {
                return true;
            }

            return false;
        }

        public ListEntity<ListUserEntity> GetListByKey(string key, int pageIndex, int pageSize)
        {
            int total = this.context.UserInfo.Where(c => c.Name.Contains(key)).Count();
            List<ListUserEntity> list = new List<ListUserEntity>();
            if (total <= 0)
            {
                return new ListEntity<ListUserEntity>(list, 0, pageIndex, pageSize);
            }
            List<string> ids = this.context.UserInfo.Where(c => c.Name.Contains(key)).OrderBy(c => c.Id).Skip((pageIndex - 1) * pageSize).Select(c => c.Id).ToList();
            BaseQuery query = new BaseQuery("SELECT us.id, de.Name as DepartmenName,us.CreateTime,res.Name as ResignName FROM UserInfo as us LEFT JOIN Department as de on us.DepartmentId=de.Id LEFT JOIN Resign as res on us.Resign=res.Id where us.id in @ids", new { ids = ids });

            // BaseQuery query = new BaseQuery("select id from UserInfo where id in @ids", new { ids =ids });
            list = DapperContext.BaseGetListByParam<ListUserEntity>(query);
            return new ListEntity<ListUserEntity>(list, total, pageIndex, pageSize);
        }

        public void Save(UserInfo entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.UserInfo.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new UserInfo();
                dbclass.Id = entity.Id;
                this.context.UserInfo.Add(dbclass);

            }

            dbclass.Address = entity.Address == null ? dbclass.Address : entity.Address;
            dbclass.Birthday = entity.Birthday == null ? dbclass.Birthday : entity.Birthday;
            dbclass.CreateTime = entity.CreateTime == null ? dbclass.CreateTime : entity.CreateTime;
            dbclass.CreateUserId = entity.CreateUserId == null ? dbclass.CreateUserId : entity.CreateUserId;
            dbclass.DepartmentId = entity.DepartmentId == null ? dbclass.DepartmentId : entity.DepartmentId;
            dbclass.Email = entity.Email == null ? dbclass.Email : entity.Email;
            dbclass.EntryTime = entity.EntryTime == null ? dbclass.EntryTime : entity.EntryTime;
            dbclass.IdentificationCard = entity.IdentificationCard == null ? dbclass.IdentificationCard : entity.IdentificationCard;
            dbclass.IsMarried = entity.IsMarried == null ? dbclass.IsMarried : entity.IsMarried;
            dbclass.LoginName = entity.LoginName == null ? dbclass.LoginName : entity.LoginName;
            dbclass.MobilePhone = entity.MobilePhone == null ? dbclass.MobilePhone : entity.MobilePhone;
            dbclass.Name = entity.Name == null ? dbclass.Name : entity.Name;
            dbclass.NativePlace = entity.NativePlace == null ? dbclass.NativePlace : entity.NativePlace;
            dbclass.Password = entity.Password == null ? dbclass.Password : entity.Password;
            dbclass.Resign = entity.Resign == null ? dbclass.Resign : entity.Resign;
            dbclass.Sex = entity.Sex == null ? dbclass.Sex : entity.Sex;
            dbclass.Status = entity.Status == null ? dbclass.Status : entity.Status;

            this.context.SaveChanges();
        }
    }
}
