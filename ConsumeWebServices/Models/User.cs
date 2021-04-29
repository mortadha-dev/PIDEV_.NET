using System;
using System.ComponentModel.DataAnnotations;

namespace ConsumeWebServices.Models
{
    public class User
    {
        public int idUser { get; set; }
        public String firstName { get; set; }
        public String username { get; set; }
        public String lastName { get; set; }
        public int telNum { get; set; }
        public String address { get; set; }
        public String mail { get; set; }
        public String birthdate { get; set; }

        [Required(ErrorMessage = "Login is required")]
        public String login { get; set; }
        [Required(ErrorMessage = "Password is required")]

        public String password { get; set; }

    }
}