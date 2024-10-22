using System.Diagnostics;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using vidly.Models;
using vidly.Utility;
using vidly.Data;

namespace vidly.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IEmailSender _emailSender;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger,IEmailSender emailSender,ApplicationDbContext context)
    {
        _logger = logger;
        _emailSender = emailSender;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult SendEmail()
    {
        return View();
    }
 
    [HttpPost]
    public IActionResult SendEmail(string EmailAdd)
    { 
        Random generator = new Random();
        String sixDigit = generator.Next(0, 1000000).ToString("D6");
         //_emailSender.SendEmailAsync(EmailAddress, "Confirm your email","Please confirm your account by");
        
        SendEmailTester tester = new SendEmailTester() {
                EmailAddress = EmailAdd,
                Pin = sixDigit,
                PinDate = DateTime.Now
            };
        
        _context.Add(tester);
        _context.SaveChanges();
        var url = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}";
        var pinUrl = url + "/Home/VerifyPin";

        ViewBag.Name = string.Format("Email is {0} , Pin is {1} And Id is {2} And url is {3}", tester.EmailAddress, tester.Pin, tester.Id,pinUrl);

        return RedirectToAction("VerifyPin", new { id = tester.Id });
    }

        public async Task<IActionResult> VerifyPin(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tester = await _context.SendEmailTesters.FindAsync(id);
            if (tester == null)
            {
                return NotFound();
            }
            return View(tester);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> VerifyPin(int id, [Bind("Id,EmailAddress,Pin,PinToVerify,PinDate")] SendEmailTester tester)
        {

            if (id != tester.Id)
            {
                return NotFound();
            }

            var emailTester = await _context.SendEmailTesters.FindAsync(id);
            if (emailTester == null)
            {
                return NotFound();
            }
            else
            {
                if(emailTester.Pin == tester.PinToVerify){
                    DateTime start = emailTester.PinDate;
                    DateTime end = DateTime.Now;
                    var result = end.Subtract(start).TotalMinutes;
                    if (result > 2)
                    {
                    ViewBag.Name = "OTP is expired.";
                    return View(tester);
                    }
                    else
                    {
                    ViewBag.Name = "OTP is valid and checked";
                    return View(tester);
                    }

                }
                else
                {
                    DateTime start = emailTester.PinDate;
                    DateTime end = DateTime.Now;
                    var result = end.Subtract(start).TotalMinutes;
                    if (result > 1)
                    {
                    ViewBag.Name = "OTP timeout after 1 min.";
                    return View(tester);
                    }
                    else
                    {
                        string sessionName = "SendEmailTester"+id;
                        if (HttpContext.Session.GetInt32(sessionName) == null) {
                            HttpContext.Session.SetInt32(sessionName,1);
                        }
                        else
                        {
                            int n = 0;
                            n = (int)HttpContext.Session.GetInt32(sessionName);
                            n = n+1;
                            HttpContext.Session.SetInt32(sessionName,n);
                        }

                        if(HttpContext.Session.GetInt32(sessionName) > 10)
                        {
                            ViewBag.Name = "OTP is wrong after 10 tries";
                            return View(tester);
                        }
                    
                    }
                    
                    ViewBag.Name = "OTP is incorrect";
                    return View(tester);

                    

                }
            }

            
            return View(tester);
        }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
