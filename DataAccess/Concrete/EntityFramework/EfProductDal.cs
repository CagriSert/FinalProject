using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entites.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {

    }
}
