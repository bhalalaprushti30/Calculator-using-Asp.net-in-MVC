using Calculator.Models;
using System;
using System.Web.Mvc;

namespace Calculator.Controllers
{
    public class CalcController : Controller
    {
        // GET: Calc
        public ActionResult Index()
        {
            return View(new calc()); // Initialize the model for the first GET request
        }

        [HttpPost]
        public ActionResult Index(calc c, string calculate)
        {
            // Perform the calculation based on the button pressed
            if (calculate == "add")
            {
                c.tot = c.no1 + c.no2;
            }
            else if (calculate == "min")
            {
                c.tot = c.no1 - c.no2;
            }
            else if (calculate == "mul")
            {
                c.tot = c.no1 * c.no2;
            }
            else if (calculate == "div")
            {
                if (c.no2 == 0)
                {
                    ModelState.AddModelError("", "Cannot divide by zero.");
                    c.tot = 0;
                }
                else
                {
                    c.tot = c.no1 / c.no2;
                }
            }
            else if (calculate == "mod")
            {
                if (c.no2 == 0)
                {
                    ModelState.AddModelError("", "Cannot mod by zero.");
                    c.tot = 0;
                }
                else
                {
                    c.tot = c.no1 % c.no2;
                }
            }
            else if (calculate == "exp")
            {
                c.tot = (int)Math.Pow(c.no1, c.no2);
            }

            return View(c); // Return the view with the model containing the result
        }
    }
}
