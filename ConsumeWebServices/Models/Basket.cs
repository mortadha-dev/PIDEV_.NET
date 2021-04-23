using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class Basket 
    {
    
        public int id { get; set; }

        [Required(ErrorMessage = "this field is required")]
        public String nameBasket { get; set; }

      [Required(ErrorMessage ="this field is required")]
        public int user_id { get; set; }

    }
}