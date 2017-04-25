using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;

namespace Yang.Management.Repository.Repository
{
    public class UserLoginRepository : IUserLoginRepository
    {
        public DataContext context = new DataContext();

        public UserLogin GetPassword(string userId)
        {
            return this.context.UserLogin.Where(c => c.UserId == userId).FirstOrDefault();
        }

        public UserLogin Login(string loginName, string password)
        {
            password = CommonEncrypt.Encrypt(password);
            return this.context.UserLogin.Where(c => c.Name == loginName && c.PassWord == password).FirstOrDefault();
        }

        public void Save(UserLogin entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
            }

            var dbclass = this.context.UserLogin.Where(c => c.Id == entity.Id).FirstOrDefault();
            if (dbclass == null)
            {
                dbclass = new UserLogin();
                dbclass.Id = Guid.NewGuid().ToString();
                this.context.UserLogin.Add(dbclass);
            }

            dbclass.PassWord = entity.PassWord == null ? dbclass.PassWord : entity.PassWord;
            dbclass.RealName = entity.RealName == null ? dbclass.RealName : entity.RealName;
            dbclass.Name = entity.Name == null ? dbclass.Name : entity.Name;
            dbclass.UserId = entity.UserId == null ? dbclass.UserId : entity.UserId;

            this.context.SaveChanges();
        }
    }
}
