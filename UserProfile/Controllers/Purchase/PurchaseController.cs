using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UserProfile.Controllers.Purchase
{
    public class PurchaseController : Controller
    {

        // GET: Purchase/Create
        public ActionResult OrderProduct()
        {
            return View();
        }

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult OrderProduct(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
