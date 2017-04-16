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
    public interface INewsRepository
    {
        void Save(News entity);

        void Delete(string id);

        int Delete(string[] ids);

        List<NewsEntity> GetAllList();

        News GetItem(string id);

        ListEntity<NewsEntity> GetList(string key, int pageIndex, int pageSize);
    }
}
