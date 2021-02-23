using DataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataManager.Library.DataAccess
{
    public interface IInventoryData
    {
        Task<List<InventoryModel>> GetInventory();
        Task SaveInventoryRecord(InventoryModel item);
    }
}
