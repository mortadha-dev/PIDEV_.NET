using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDEV.Models
{
    public class SaleDepartment
    {
		public long idSale { get; set; }
		[JsonProperty("saleName")]
		public String SaleName { get; set; }
		[JsonProperty("capacity")]
		public int capacity { get; set; }

		[JsonProperty("departmentType")]
		public String DepartmentType { get; set; }



	}
}