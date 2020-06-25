using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserProfile.Models
{
    public class Unit
    {
        public int ProductAcount { get; set; }

        public int ProductBcount { get; set; }

        public int ProductCcount { get; set; }

        [Display(Name = "Product A Price")]
        public int ProductAprice { get; set; }

        [Display(Name = "Product B Price")]
        public int ProductBpricet { get; set; }

        [Display(Name = "Product C Price")]
        public int ProductCprice { get; set; }
    }
}