using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yang.Management.Entity
{
    public class ListEntity<T>
    {
        public List<T> Entity { get; set; }

        public int TotalPage { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public ListEntity(List<T> Entity, int TotalNumber,int PageIndex, int PageSize)
        {
            this.Entity = Entity;
            this.TotalPage = TotalNumber / PageSize;
            if (TotalNumber % PageSize != 0)
            {
                this.TotalPage++;
            }

            this.PageSize = PageSize;
            this.PageIndex = PageIndex;
        }

        public ListEntity()
        {
        }
    }
}
