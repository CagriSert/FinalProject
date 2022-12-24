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
                return new ErrorDataResult<List<Product>>(Messages.MaintenceTime);
            }

            var data = _productDal.GetAll(); ;
            return new SuccessDataResult<List<Product>>(data, Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            var data = _productDal.GetAll(x => x.CategoryId == id);
            return new SuccessDataResult<List<Product>>(data, Messages.ProductListed);

        }

        public IDataResult<Product> GetById(int id)
        {
            var data = _productDal.Get(x => x.ProductId == id);
            return new SuccessDataResult<Product>(data, Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            var data = _productDal.GetAll(x => x.UnitPrice >= min && x.UnitPrice <= max);
            return new SuccessDataResult<List<Product>>(data, Messages.ProductListed);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            var data = _productDal.GetProductDetails();
            return new SuccessDataResult<List<ProductDetailDto>>(data, Messages.ProductListed);
        }
    }
}
