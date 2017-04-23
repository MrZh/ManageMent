﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yang.Management.Entity;
using Yang.Management.Entity.DataEntity;
using Yang.Management.Entity.ViewEntity;

namespace Yang.Management.Repository
{
    public interface IDimissionRecordRepository
    {
        void Save(DimissionRecord entity);

        ListEntity<ListDimissionRecordEntity> GetListByUserId(string id, int pageIndex, int pageSize);
    }
}
