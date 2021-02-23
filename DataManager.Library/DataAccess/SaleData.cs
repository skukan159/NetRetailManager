using DataManager.Library.Internal.DataAccess;
using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class SaleData : ISaleData
    {
        private string connectionString;

        public SaleData(string connString)
        {
            connectionString = connString;
        }

        public async Task SaveSale()
        {
            // TODO
            SqlDataAccess sql = new SqlDataAccess();

            List<SaleDetailModel> details = new List<SaleDetailModel>();

            throw new NotImplementedException();

            //var output = await sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, connectionString);

            //return output;
        }

        public async Task<List<SaleReportModel>> GetSaleReport()
        {
            SqlDataAccess sql = new SqlDataAccess();
            var output = await sql.LoadData<SaleReportModel, dynamic>("dbo.spSale_SaleReport", new { }, connectionString);
            return output;
        }
    }
}
