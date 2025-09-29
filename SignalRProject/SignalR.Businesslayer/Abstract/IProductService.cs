using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Businesslayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        List<Product> TGetProductsWithCategories();

        int TGetProductCount();

        public string ProductNameByMaxPrice();
        public string ProductNameByMinPrice();
        List<Product> TGetLast9Products();

    }
}
