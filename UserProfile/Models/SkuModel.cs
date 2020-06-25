using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserProfile.Models
{
    public class SkuModel
    {
        public int Id { get; set; }

        public Unit Product { get; set; }

        [Display(Name = "Product")]
        public string ProductA { get; set; }

        public int ProductAcount { get; set; }

        [Display(Name = "Product A Price")]
        public int ProductAprice { get; set; }



        [Display(Name = "Product ")]
        public string ProductB { get; set; }

        public int ProductBcount { get; set; }

        [Display(Name = "Product B Price")]
        public int ProductBprice { get; set; }



        [Display(Name = "Product ")]
        public string ProductC { get; set; }

        public int ProductCcount { get; set; }

        [Display(Name = "Product C Price")]
        public int ProductCprice { get; set; }


        [Display(Name = "Product ")]
        public string ProductD { get; set; }

        public int ProductDcount { get; set; }

        [Display(Name = "Product D Price")]
        public int ProductDprice { get; set; }


        public int Total { get { return ProductAprice + ProductBprice + ProductCprice + ProductDprice; } }
    }
}