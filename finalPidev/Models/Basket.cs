using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finalPidev.Models
{
    public class Basket
    {
        public int id { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public String nameBasket { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public int user_id { get; set; }

    }
}