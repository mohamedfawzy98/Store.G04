using Store.G04.Core.Entites;
using Store.G04.Core.Spectifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core
{
    public class ProductWithCount : Sepctifcation<Product , int>
    {
        public ProductWithCount(string? sort, int? brandid, int? typeid, int pagesize, int pageindex , string search) : base(
           p =>
           (string.IsNullOrEmpty(search) || p.Name.Contains(search))
           &&
           (!brandid.HasValue || brandid == p.BrandId)
           &&
           (!typeid.HasValue || typeid == p.TypeId)
           )
        {

        }
    }
}
