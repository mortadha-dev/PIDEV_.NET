using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{
    public class Product
	{
		public int id { get; set; }
		public int Code { get; set; }
		public String NameProduct { get; set; }
		public Double priceProduct { get; set; }
		public Double Weight { get; set; }
		public String Description { get; set; }
		public int quantity { get; set; }
		public String Picture { get; set; }

       
    }
}