using DataManager.Library.Internal.DataAccess;
using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public class InventoryData : IInventoryData
    {
        private string _connectionString;

        public InventoryData(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<List<InventoryModel>> GetInventory()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = await sql.LoadData<InventoryModel, dynamic>("dbo.spInventory_GetAll", new { }, _connectionString);

            return output;
        }

        public async Task SaveInventoryRecord(InventoryModel item)
        {
            SqlDataAccess sql = new SqlDataAccess();

            await sql.SaveData("dbo.spInventory_Insert", item, _connectionString);
        }
    }
}
