using SignalR.Businesslayer.Abstract;
using SignalR.DataAccesslayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Businesslayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public string ProductNameByMaxPrice()
        {
            return _productDal.ProductNameByMaxPrice();
        }

        public string ProductNameByMinPrice()
        {
            return _productDal.ProductNameByMinPrice();
        }

        public void TAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void TDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Product TGetByID(int id)
        {
            return _productDal.GetByID(id);
        }

        public List<Product> TGetLast9Products()
        {
            return _productDal.GetLast9Products();
        }

        public List<Product> TGetListAll()
        {
            return _productDal.GetListAll();
        }

        public int TGetProductCount()
        {
            return _productDal.ProductCount();
        }

        public List<Product> TGetProductsWithCategories()
        {
            return _productDal.GetProductsWithCategories();
        }

        public void TUpdate(Product entity)
        {
            _productDal.Update(entity);
        }
    }
}
