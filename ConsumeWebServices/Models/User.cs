﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class User
    {
        public int idUser { get; set; }
        public String firstName { get; set; }

        public String lastName { get; set; }
        public int telNum { get; set; }
        public String address { get; set; }
        public String birthdate { get; set; }
        public String login { get; set; }

        public String password { get; set; }

    }
}