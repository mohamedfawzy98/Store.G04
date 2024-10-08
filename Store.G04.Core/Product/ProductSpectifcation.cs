using Store.G04.Core.Spectifications;
using Store.G04.Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G04.Core
{
    public class ProductSpectifcation : Sepctifcation<Product,int>
    {
        public ProductSpectifcation(int id) : base(P => P.Id == id)
        {
            ApplyIncludes();
        }

        public ProductSpectifcation(string ? sort , int? brandid, int? typeid , int pagesize , int pageindex, string search) : base(
            p=>
            (string.IsNullOrEmpty(search) || p.Name.Contains(search))
            &&
            (!brandid.HasValue || brandid == p.BrandId)
            &&
            (!typeid.HasValue || typeid == p.TypeId)
            )
        {
            if(!string.IsNullOrEmpty(sort))
            {
                switch(sort)
                {
                    case "priceAsc":
                        OrdrByAssc(P => P.Price);
                        break;
                    case "PriceDesc":
                        OrdrByDesse(P => P.Price);
                        break;
                    default:
                        OrdrByAssc(P => P.Name);
                        break;
                }
            }
            else
            {
                OrdrByAssc(P => P.Name);
            }
            ApplyIncludes();
            ApplyPagination(pagesize *(pageindex -1) , pagesize);
        }

        private void ApplyIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Type);
        }
    }
}
