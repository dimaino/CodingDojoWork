using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankAccounts.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.Controllers
{
    
    public class BankController : Controller
    {
        private MasterContext _context;
 
        public BankController(MasterContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("account")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("CurrUserId") != null)
            {
                ViewBag.currentUser = _context.Users.SingleOrDefault(user => user.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                ViewBag.allUsersAccounts = _context.Users.Include(accounts => accounts.Accounts).ToList();
                return View("Index");
            }
            return RedirectToAction("Index", "Login");
        }

        [HttpGet]
        [Route("accountSetupPage")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult AccountSetupPage()
        {
            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            return View("AccountSetup");
        }

        [HttpPost]
        [Route("makeAccount")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult MakeAccount(MakeAccountViewModel model)
        {
            if(ModelState.IsValid)
            {
                Random rand = new Random();
                int accountNumber;
                Accounts accountCheck;
                do
                {
                    accountNumber = rand.Next(1000000,9999999);
                    accountCheck = _context.Accounts.SingleOrDefault(account => account.Number == accountNumber);
                }while(accountCheck != null);
                Accounts newAccount = new Accounts
                {
                    Balance = double.Parse(model.Balance, System.Globalization.CultureInfo.InvariantCulture),
                    Number = accountNumber,
                    created_at = DateTime.Now,
                    updated_at = DateTime.Now
                };
                Users currentUser = _context.Users.SingleOrDefault(user => user.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                currentUser.Accounts.Add(newAccount);
                
                _context.SaveChanges();
                TempData["error_list"] = new List<string>() {"Account Created!"};
                return RedirectToAction("AccountSetupPage");
            }
            List<string> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("AccountSetupPage");
        }

        [HttpGet]
        [Route("backToAccounts")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult BackToAccounts()
        {
            HttpContext.Session.Remove("CurrentAccount");
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("viewAccount/{id}")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult ViewAccount(int id)
        {
            ViewBag.account = _context.Accounts.SingleOrDefault(account => account.id == id);
            HttpContext.Session.SetInt32("CurrentAccount", id);
            return View("Account");
        }

        [HttpGet]
        [Route("/goToDepositPage")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult goToDepositPage()
        {
            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            ViewBag.account = _context.Accounts.SingleOrDefault(account => account.id == (int)HttpContext.Session.GetInt32("CurrentAccount"));
            return View("Deposits");
        }

        [HttpGet]
        [Route("/goToWithdrawalPage")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult GoToWithdrawalPage()
        {
            if(TempData["error_list"] != null)
            {
                ViewBag.errors = TempData["error_list"];
            }
            ViewBag.account = _context.Accounts.SingleOrDefault(account => account.id == (int)HttpContext.Session.GetInt32("CurrentAccount"));
            return View("Withdrawals");
        }

        [HttpPost]
        [Route("makeDeposit")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult MakeDeposit(MondeyViewModel model)
        {
            if(ModelState.IsValid)
            {
                Deposits newDeposit = new Deposits
                    {
                        amount = double.Parse(model.amount, System.Globalization.CultureInfo.InvariantCulture),
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    Accounts currentAccount = _context.Accounts.SingleOrDefault(account => account.id == (int)HttpContext.Session.GetInt32("CurrentAccount"));
                    currentAccount.Balance += newDeposit.amount;
                    currentAccount.Deposits.Add(newDeposit);
                    Users currentUser = _context.Users.SingleOrDefault(user => user.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                    currentUser.Deposits.Add(newDeposit);
                    _context.SaveChanges();
                    return RedirectToAction("goToDepositPage");
            }
            List<string> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("goToDepositPage");
        }

        [HttpPost]
        [Route("makeWithdrawal")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult MakeWithdrawal(MondeyViewModel model)
        {
            if(ModelState.IsValid)
            {
                Withdrawals newWithdrawal = new Withdrawals
                    {
                        amount = double.Parse(model.amount, System.Globalization.CultureInfo.InvariantCulture),
                        created_at = DateTime.Now,
                        updated_at = DateTime.Now
                    };
                    Accounts currentAccount = _context.Accounts.SingleOrDefault(account => account.id == (int)HttpContext.Session.GetInt32("CurrentAccount"));
                    currentAccount.Balance -= newWithdrawal.amount;
                    currentAccount.Withdrawals.Add(newWithdrawal);
                    Users currentUser = _context.Users.SingleOrDefault(user => user.id == (int)HttpContext.Session.GetInt32("CurrUserId"));
                    currentUser.Withdrawals.Add(newWithdrawal);
                    _context.SaveChanges();
                    return RedirectToAction("goToWithdrawalPage");
            }
            List<string> errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y=>y.Count>0)
                           .Select(z => z[0].ErrorMessage.ToString())
                           .ToList();
            TempData["error_list"] = errors;
            return RedirectToAction("goToWithdrawalPage");
        }



        [HttpGet]
        [Route("logout")]
        [ResponseCache(NoStore =true, Location =ResponseCacheLocation.None)]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}