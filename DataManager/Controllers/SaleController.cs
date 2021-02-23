using DataManager.Contracts;
using DataManager.Contracts.V1.DTO.Auth;
using DataManager.Domain.DAO;
using DataManager.Library.DataAccess;
using DataManager.Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private ISaleData _saleData;



        public SaleController(SaleData saleData)
        {
            _saleData = saleData;
        }

        // TODO
        [HttpPost(ApiRoutes.Sale.Post)]
        public ActionResult<SaleResponse> Post(CreateSaleRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpGet(ApiRoutes.Sale.GetSalesReport)]
        public async Task<ActionResult<SaleResponse>> GetSalesReport()
        {
            var response = await _saleData.GetSaleReport();

            throw new NotImplementedException();
            //TODO - Create response object and map to the response obj

            //return response;

        }
    }
}
