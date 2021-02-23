using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public interface IProductData
    {
        Task<List<ProductModel>> GetProducts();
        Task<ProductModel> GetProductById(int productId);
    }
}
