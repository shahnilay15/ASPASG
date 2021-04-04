using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;

namespace Test.Controllers
{
    [Authorize]
    public class ICBController : Controller
    {
        private readonly ICB _number;

        public ICBController(ICB number)
        {
            _number = number;
        }
        private static int i;

        public IActionResult Index(string guess)
        {
            String AllowedChars = @"[0-9]";

            if (guess != null && (Regex.IsMatch(guess, AllowedChars)))
            {


                string str = "You Won";

                var res = _number.Compare(guess);
               

                ViewBag.message = $"{res}";

                return View();
            }
            else
            {

                return View();
            }


        }
    }

}
