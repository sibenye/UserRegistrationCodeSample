using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using UserRegistrationSample.Models;
using UserRegistrationSample.Repositories;

namespace UserRegistrationSample.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            ViewBag.Title = "Register";
            return View();
        }
    }
}
