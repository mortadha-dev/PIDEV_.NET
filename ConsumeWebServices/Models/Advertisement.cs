using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIDEV.Models
{
    public class Advertisement
    {
		public long  id_advertisement { get; set; }

		public String canal { get; set; }

		public DateTime beginningDate { get; set; }


		public DateTime endDate { get; set; }

		public int targetViews { get; set; }
		public int views { get; set; }

		public String channel_type { get; set; }
		public String typeAd { get; set; }

	    private Product Produit;
	}
}