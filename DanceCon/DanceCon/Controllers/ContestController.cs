using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DanceCon.Context;
using DanceCon.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace DanceCon.Controllers
{
    public class ContestController : Controller
    {
        private readonly IHostingEnvironment hostingEnvironment;
        protected UserManager<IdentityUser> UserManager { get; }
        protected SignInManager<IdentityUser> SignInManager { get; }
        public ContestController(IHostingEnvironment hostingEnvironment, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.hostingEnvironment = hostingEnvironment;
            SignInManager = signInManager;
            UserManager = userManager;
        }

        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contestlist(string sortOrder)
        {
            var context = new EFCContext();

            List<ContestViewModel> pm = new List<ContestViewModel> { };
            var con = from c in context.Contests select c;

            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "title_desc":
                    con = con.OrderBy(c => c.Title);
                    break;
                case "country_desc":
                    con = con.OrderBy(c => c.Country);
                    break;
                case "Date":
                    con = con.OrderBy(c => c.ContestDate);
                    break;
                case "date_desc":
                    con = con.OrderByDescending(c => c.ContestDate);
                    break;
                default:
                    con = con.OrderBy(c => c.ContestDate);
                    break;
            }

            return View("Contestlist", con.ToList()); 
        }

        [HttpGet]
        public IActionResult UserEvent(string sortOrder)
        {
            var context = new EFCContext();
            var userID = "";
            if (User.Identity.IsAuthenticated)
            {
                userID = UserManager.GetUserId(User);
            }
     
            List<ContestViewModel> pm = new List<ContestViewModel> { };
            var con = from c in context.Contests select c;

            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "title_desc":
                    con = con.OrderBy(c => c.Title);
                    break;
                case "country_desc":
                    con = con.OrderBy(c => c.Country);
                    break;
                case "Date":
                    con = con.OrderBy(c => c.ContestDate);
                    break;
                case "date_desc":
                    con = con.OrderByDescending(c => c.ContestDate);
                    break;
                default:
                    con = con.OrderBy(c => c.ContestDate);
                    break;
            }

            var usercontest = con.Where(x => x._UserID == userID).ToList();
            return View("UserEvent", usercontest);

        }

        [HttpGet]
        public IActionResult UserPart(string sortOrder)
        {
            var context = new EFCContext();
            var userID = "";
            if (User.Identity.IsAuthenticated)
            {
                userID = UserManager.GetUserId(User);
            }

            List<ContestViewModel> pm = new List<ContestViewModel> { };
            var con = from c in context.Contests select c;


            ViewBag.TitleSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "title_desc":
                    con = con.OrderBy(c => c.Title);
                    break;
                case "country_desc":
                    con = con.OrderBy(c => c.Country);
                    break;
                case "Date":
                    con = con.OrderBy(c => c.ContestDate);
                    break;
                case "date_desc":
                    con = con.OrderByDescending(c => c.ContestDate);
                    break;
                default:
                    con = con.OrderBy(c => c.ContestDate);
                    break;
            }
            var userparticipant = context.Participants.Where(x => x._UserID == userID).ToList();
            var contestID = 0;
            ContestViewModel ct;
            foreach (var part in userparticipant)
            {
                contestID = part._ContestID;
                ct = con.Single(x => x.ID == contestID);
                pm.Add(ct);
            }
            return View("UserPart", pm);

        }
        
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Participants(int id, [FromServices] EFCContext context)
        {
            var CM = new ContestManger();

            var participant = CM.GetParticipants(id);
            return View("Participants", participant);
        }
       
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult Add(ContestModel contest,[FromServices] EFCContext context)
        {
            if(context.Contests.Any(x=> x.Title == contest.Title))
            {

                ModelState.AddModelError("Title", "Contest with this title exist");
                return View();
            }
            else if(contest.ContestDate < DateTime.Now)
            {

                ModelState.AddModelError("ContestDate", "NO PAST CONTEST");
                return View();

            }
            if (ModelState.IsValid)
            {
                var userIdValue = "";
                var claimsIdentity = User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                   
                    var userIdClaim = claimsIdentity.Claims
                        .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                        userIdValue = userIdClaim.Value;
                    }
                }

                string uniqueFileName = null;
                if (contest.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + contest.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    contest.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var pm = new ContestManger();
                var contestModel = new ContestViewModel
                {

                    Title = contest.Title,
                    Country = contest.Country,
                    City = contest.City,
                    Categories = contest.Categories,
                    //Judges = contest.Judges,
                    Type = contest.Type,
                    Description = contest.Description,
                    ContestDate = contest.ContestDate,
                    AddedDate = DateTime.Now,
                    _UserID = userIdValue,
                    PhotoPath = uniqueFileName

                };


                pm.AddContest(contestModel);
                /*   foreach (var j in contest.Judges)
                   {
                       var judgesmodel = new Judge
                       {
                           _JudgeName = j.ToString(),


                       };
                       pm.AddJudge(judgesmodel);
                   }
                   */


                ViewData["Massage"] = contestModel;
                UserManager.AddToRoleAsync(context.Users.Single(x=>x.Id==uniqueFileName), "contestAdmin");
                return View("AddJudge");
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddJudge()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddJudge(IFormCollection fc, [FromServices] EFCContext context)
        {
            string test = fc["texttest"];
            var judge = test.Split(",");
            var pm = new ContestManger();
            var cust = context.Contests.Last() ;

            int id = cust.ID;
            
            foreach (var j in judge)
            { var judgemodel = new Judge
            {

                _JudgeName = j,
                _ContestID = id
              

            };
            pm.AddJudge(judgemodel); }


            return RedirectToAction("Details");
        }
        [HttpGet]
        public IActionResult Details([FromServices] EFCContext context)
        {
          
            var cust = context.Contests.Last();
            DetailViewModel mymodel = new DetailViewModel();
            mymodel.Contests = context.Contests.Single(x => x.ID == cust.ID);
            mymodel.Judges = context.Judges.Where(x => x._ContestID == cust.ID).ToList();
            return View("Details", mymodel);
            
        }
        [HttpGet]
        public IActionResult Detail(int id,[FromServices] EFCContext context)
        {
            DetailViewModel mymodel = new DetailViewModel();
            mymodel.Contests = context.Contests.Single(x => x.ID == id);
            mymodel.Judges = context.Judges.Where(x => x._ContestID == id).ToList();

            return View("Detail", mymodel);

        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult AddPart(int id, [FromServices] EFCContext context)
        {
            return View();
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult AddPart(int id, [FromServices] EFCContext context, ParticipantViewModel part)
        {
            var cont = context.Contests.Single(x => x.ID == id);
            if (string.IsNullOrEmpty(part.Name))
            {

                ModelState.AddModelError("Name", "Please enter your name");
                return View();
            }
            var today = DateTime.Today;
            var age = today.Year - part.BirthDate.Year;
            if (cont.TypeText == "Open" || (cont.TypeText=="Adults" && age>=18) || (cont.TypeText == "Kids" && age <= 18))
            {
                if (ModelState.IsValid)
                {

                        var userIdValue = "";
                        var claimsIdentity = User.Identity as ClaimsIdentity;
                        if (claimsIdentity != null)
                        {
                            // the principal identity is a claims identity.
                            // now we need to find the NameIdentifier claim
                            var userIdClaim = claimsIdentity.Claims
                                .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier);

                            if (userIdClaim != null)
                            {
                                userIdValue = userIdClaim.Value;
                            }
                        }


                        var pm = new ContestManger();
                    var participant = new ParticipantViewModel
                    {

                        Name = part.Name,
                        Country = part.Country,
                        City = part.City,
                        _ContestID = cont.ID,
                        BirthDate = part.BirthDate,
                        _UserID = userIdValue 


                    };


                    pm.AddParticipant(participant);
                   
                }
                return RedirectToAction("Contestlist");
            }
            else
            {

                ModelState.AddModelError("BirthDate", "This contest is not for your age");
                return View();
            }
           
            
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult RemoveContest(int id, [FromServices] EFCContext context)
        {
            ViewBag.contestid = id;
            var cont = context.Contests.Single(x => x.ID == id);
            return View(cont);
            
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult RemoveContest(int id)
        {

            var pm = new ContestManger();
            pm.RemoveContest(id);
            return  RedirectToAction("Contestlist");

        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult EditContest(int id, [FromServices] EFCContext context)
        {
            
            var cont = context.Contests.Single(x => x.ID == id);
            return View(cont);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult EditContest(ContestViewModel contest, [FromServices] EFCContext context)
        {

            var pm = new ContestManger();
            pm.UpdatePost(contest);
            return RedirectToAction("Contestlist");
        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult RemovePart(int id, [FromServices] EFCContext context)
        {
            ViewBag.contestid = id;
            var part = context.Participants.Single(x => x.ID == id);
            return View(part);



        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult RemovePart(int id)
        {


            var pm = new ContestManger();
            pm.RemovePart(id);
            return RedirectToAction("Contestlist");



        }
        [Authorize(Roles = "User")]
        [HttpGet]
        public IActionResult EditPart(int id, [FromServices] EFCContext context)
        {

            var part = context.Participants.Single(x => x.ID == id);
            return View(part);
        }
        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult EditPart(ParticipantViewModel part, [FromServices] EFCContext context)
        {

            var pm = new ContestManger();
            pm.UpdatePart(part);
            return RedirectToAction("Contestlist");
        }
    }
}