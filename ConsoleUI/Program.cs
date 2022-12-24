using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();
            //CategoryTest();
            ProductManager productManager = new ProductManager(new EfProductDal());
            var data = productManager.GetProductDetails();
            if (data.Success)
            {
                foreach (var item in data.Data)
                {
                    Console.WriteLine(item.CategoryName);
                }
            }
        }

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    foreach (var item in categoryManager.GetAll())
        //    {
        //        Console.WriteLine(item.CategoryName);
        //    }
        //}

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    foreach (var product in productManager.GetByUnitPrice(20, 40))
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //}
    }
}
