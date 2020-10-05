using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        employeedb dbop = new employeedb();
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index([Bind] employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   string res= dbop.Saverecord(emp);
                    TempData["msg"] = res;
                }
            }
            catch (Exception ex)
            {
                TempData["msg"] = ex.Message;
            }
            return View();
        }
    }
}
