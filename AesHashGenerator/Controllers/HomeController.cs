using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AesHashGenerator.Controllers
{
    public class HomeController : Controller
    {
     

        public ActionResult Index(HashGenViewModel hashGenViewModel)
        {
            return View(new HashGenViewModel() { HashedValue = String.Empty, HashSecret = String.Empty, ValueToBeHashed = String.Empty});
        }


        [HttpPost]
      
        public ActionResult Hash(HashGenViewModel hashGenViewModel) {
            if (!String.IsNullOrWhiteSpace(hashGenViewModel.HashSecret) && !String.IsNullOrWhiteSpace(hashGenViewModel.ValueToBeHashed)) {


                HMACSHA512 hashSvc = new HMACSHA512(Encoding.Unicode.GetBytes( hashGenViewModel.HashSecret));
                byte[] hashBytes = hashSvc.ComputeHash(Encoding.Unicode.GetBytes(hashGenViewModel.ValueToBeHashed));
                hashGenViewModel.HashedValue = Convert.ToBase64String(hashBytes);
            }

            return View("Index", hashGenViewModel);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


    public class HashGenViewModel
    {
        public string HashSecret { get; set; }
        public string ValueToBeHashed { get; set; }
        public string HashedValue { get; set; }
    }

}