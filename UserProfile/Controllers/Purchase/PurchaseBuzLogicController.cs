using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserProfile.Models;
using UserProfile.Utility;

namespace UserProfile.Controllers.Purchase
{
    public class PurchaseBuzLogicController : Controller
    {
        public JsonResult GetTotal(SkuModel model)
        {
            var price = Promotion.Instance.GetTotal(model);
            return Json(price);
        }
    }
}