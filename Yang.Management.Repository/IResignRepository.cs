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
    public interface IResignRepository
    {
        void Save(Resign entity);

        void Delete(string id);

        int Delete(string[] ids);

        List<ListResignEntity> GetAllList();

        Resign GetItem(string id);

        ListEntity<ListResignEntity> GetList(string key, int pageIndex, int pageSize);
    }
}
