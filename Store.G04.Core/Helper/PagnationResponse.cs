using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core.Helper
{
    public class PagnationResponse<TEntity>
    {
        public PagnationResponse(int pagesize, int pageindex, int count, IEnumerable<TEntity> data)
        {
            Pagesize = pagesize;
            PageIndex = pageindex;
            Count = count;
            Data = data;
        }

        public int Pagesize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IEnumerable<TEntity> Data { get; set; }
    }
}
