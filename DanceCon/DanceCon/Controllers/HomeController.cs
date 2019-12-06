using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanceCon.Context;
using DanceCon.Models;
using Microsoft.AspNetCore.Mvc;

namespace DanceCon.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index([FromServices]EFCContext context)
        {   var con = from c in context.Contests select c;
            con = con.OrderBy(c => c.ContestDate);
     
      
            List<ContestViewModel> pm = new List<ContestViewModel> { };


         
                
            return View(con.ToList());
        }
    }
}