using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository
{
    public interface IUserInfoRepository
    {
        void Save(UserInfo entity);

        void Delete(string id);

        ListEntity<ListUserEntity> GetListByKey(string key, int pageIndex,int pageSize);
    }
}
