using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Monitor.Models;
using API_Monitor.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API_Monitor.Controllers
{
   // [Route("Dashboard/[controller]")]
    public class ApiLogController : Controller
    {
        private readonly IRepository _repository;

        public ApiLogController(IRepository repository) => _repository = repository;

        public ActionResult Index()
        {
            var dashview = getAllApiLogs();

            ViewBag.DropdownFeed = getUniqueAPIList(dashview);

            return View(dashview);
        }

        public JsonResult getUpdates()
        {
            HttpContext.Session.SetInt32("lastCount", 1); 

            var dashview = getAllApiLogs();
            
            ViewBag.Change = 2;

            if (HttpContext.Session.GetInt32("lastCount") == null || dashview.Count() != HttpContext.Session.GetInt32("lastCount"))
            {
                ViewBag.Change = 1; 
            }
         //   ViewBag.DropdownFeed = getUniqueAPIList(dashview);
            return Json(dashview);
        }

        public ActionResult Details(string id)
        {
            var details = getSingleLog(id);
            return View(details); 
        }

        public List<string> getUniqueAPIList(List<ApiLog> dashview) => _repository.getUniqueAPIList(dashview);

        public List<ApiLog> getAllApiLogs()
        {
            return _repository.getAllApiLogs(); 
        }

        public ApiLog getSingleLog(string id) => _repository.getSingleLog(id);

        public List<ApiLog> getAPIspecificLog(string api) => _repository.getAPIspecificLog(api);
    }
}
