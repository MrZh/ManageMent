using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository
{
    public interface IDepartmentRepository
    {
        void Save(Department entity);

        void Delete(string id);

        List<ListDepartmentEntity> GetAllList();
    }
}