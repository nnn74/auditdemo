using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using auditproblem.Models;
using auditproblem.Data;

namespace auditproblem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TriggerError()
        {
            ViewData["Message"] = "Trigger error";
            
            var parent = new Parent { Name = "PARENT 1" };
            var child = new Child { Name = "CHILD 1", Period = new Period { Start = new DateTime(2017, 1, 1), End = new DateTime(2018, 1, 1) } };
            parent.Children = new List<Child> { child };

            await _dbContext.Parents.AddAsync(parent);
            await _dbContext.SaveChangesAsync();

            return View(parent);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
