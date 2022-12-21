using Core.DataAcces;
using Entites.Concrete;

namespace DataAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
