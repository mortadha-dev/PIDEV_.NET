using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDEV.Models
{
    public class Category
    {
        public long idCategory { get; set; }
        [JsonProperty("categoryName")]
        public  String CategoryName { get; set; }
        [JsonProperty("description")]
        public  String Description { get; set; }
        //public virtual ICollection<Product> Products { get; set; }


    }
}