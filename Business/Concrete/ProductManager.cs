using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            this._productDal = productDal;
        }

        public IResult Add(Product product)
        {
            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }

            _productDal.Add(product);

            return new SueccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult();
            }
            var data = _productDal.GetAll(); ;
            return new SuccessDataResult<List<Product>>(data, true, "Ürünler listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(x => x.CategoryId == id);
        }

        public IDataResult<Product> GetById(int id)
        {
            return _productDal.Get(x => x.ProductId == id);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max);
        }

        public IDataResult<List<Product>> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
