using Newtonsoft.Json;
using NHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PIDEV.Models
{
    public class Product
    {

		[JsonProperty("idProduct")]
		public  long idProduct { get; set; }
		[Required(ErrorMessage = "Code is Required")]
		[JsonProperty("code")]
		public long Code { get; set; }
		[JsonProperty("nameProduct")]
		public String NameProduct { get; set; }
		[JsonProperty("priceProduct")]
		public float  priceProduct { get; set; }
		[JsonProperty("weight")]
		public float  Weight { get; set; }
		[JsonProperty("description")]
		public String Description { get; set; }


		public byte[] content { get; set; }


		//	[ForeignKey("idCategory ")]
	//	public int idCategory { get; set; }

		public virtual Category idCategory { get; set; }


		//public   Category idCategory { get; set; }

		//@ManyToOne 

		//   private virtual Category idCategory;

	}
}