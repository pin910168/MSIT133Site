using Microsoft.AspNetCore.Mvc;
using MSIT133Site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MSIT133Site.Controllers
{
    public class APIController : Controller
    {
        //private readonly DemoContext _context;

        //public APIController(DemoContext context)
        //{
        //    _context = context;
        //}

        public IActionResult Index(string name, int age)
        {
            System.Threading.Thread.Sleep(10000);
            if (string.IsNullOrEmpty(name))
            {
                name = "Ajax";
            }
            return Content("Hello " + name + "," + age, "text/plain", System.Text.Encoding.UTF8);
        }

        public IActionResult cEmail(string email)
        {
            string txtem = "";
            if (email != null)
            {
                DemoContext db = new DemoContext();
                var datas =  db.Members.FirstOrDefault(em => em.Email == email);

                //var datas = _context.Members.FirstOrDefault(m => m.Email == email);
                if (datas != null)
                {
                    txtem = "此信箱已經被使用了!!";
                }
                else
                {
                    txtem = "此信箱可使用!!";
                }
            }
            else
            {
                txtem = "請輸入您的信箱!";
            }
            return Content(txtem , "text/plain", System.Text.Encoding.UTF8);
        }
    }
}
