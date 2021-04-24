using System;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebServices.Models
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