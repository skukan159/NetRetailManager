using DataManager.Library.Internal.DataAccess;
using DataManager.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly string connectionString;

        public ProductData(string connString)
        {
            connectionString = connString;
        }

        public async Task<List<ProductModel>> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = await sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, connectionString);

            return output;
        }

        public async Task<ProductModel> GetProductById(int productId)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = await sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, connectionString);

            return output[0];
        }



    }
}
