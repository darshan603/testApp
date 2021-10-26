using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using testApp.Models;
using testApp.Models.ViewModels;
using testApp.Repository.IRepository;

namespace testApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger,IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

       
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            SaleVM saleVM = new SaleVM()
            {
                Sales= await _unitOfWork.Sales.GetAsync(id),
                SalesLines= await _unitOfWork.SalesLines.GetAllAsync(x=>x.SSalesID==id)
            };
            return View(saleVM);
        }


        public IActionResult  Add()
        {
            Sales sales = new Sales()
            {
                SalesDate = DateTime.Now
            };
            return View(sales);
        }
        public IActionResult  AddLine(int saleId)
        {
            TempData["saleId"] = saleId;
            SalesLines salesLines = new SalesLines()
            {
                SSalesID = saleId
            };
            return View(salesLines);
        }


        [HttpPost]
        public async Task<IActionResult> AddLine(SalesLines salesLines)
        {
            if (ModelState.IsValid)
            {
                salesLines.Total = salesLines.Quantity * salesLines.UnitPrice;
                await _unitOfWork.SalesLines.AddAsync(salesLines);

                _unitOfWork.Save();              
                return RedirectToAction(nameof(AddLine), new { saleId = salesLines.SSalesID });
            }
            return View(salesLines);
        }



        [HttpPost]
        public async Task<IActionResult>  Add(Sales sales)
        {
            if(ModelState.IsValid)
            {
                await _unitOfWork.Sales.AddAsync(sales);
                _unitOfWork.Save();
                var sales1 = _unitOfWork.Sales.GetAllAsync().GetAwaiter().GetResult().OrderByDescending(a => a.SalesID).FirstOrDefault();
                return RedirectToAction(nameof(AddLine), new { saleId = sales1.SalesID });
            }
            return View(sales);
        }



        [HttpGet]
        public async Task<IActionResult> GetAllSaleList()
        {
            int saleId = Convert.ToInt32(TempData.Peek("saleId"));
            var alf = await _unitOfWork.SalesLines.GetAllAsync(x=>x.SSalesID==saleId);
            return Json(new { data = alf });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustList()
        {           
            var alf = await _unitOfWork.Sales.GetAllAsync();
            return Json(new { data = alf });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSaleLine(int id)
        {
            var objFromDb = await _unitOfWork.SalesLines.GetAsync(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.SalesLines.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
