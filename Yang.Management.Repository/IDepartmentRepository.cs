using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository
{
    public interface IDepartmentRepository
    {
        void Save(Department entity);

        void Delete(string id);

        int Delete(string[] ids);

        List<ListDepartmentEntity> GetAllList();

        Department GetItem(string id);

        ListEntity<ListDepartmentEntity> GetList(string key, int pageIndex, int pageSize);
    }
}