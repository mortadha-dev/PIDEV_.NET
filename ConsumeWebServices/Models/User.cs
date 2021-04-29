using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumeWebServices.Models
{// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class User
    {
        public int idUser { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("telNum")]
        public int TelNum { get; set; }

        [JsonProperty("birthdate")]
        public DateTime Birthdate { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
        public RoleType RoleType { get; set; }
        public Boolean valid { get; set; }
        public Boolean accountNonLocked { get; set; }
        public String stripeid { get; set; }
        public String resettoken { get; set; }
        public int failedAttempt { get; set; }

    }


    /*public class User
    {
		

	public int idUser { get; set; }
		public String lastName { get; set; }
		public String firstName { get; set; }
		public int telNum { get; set; }
		public DateTime birthdate { get; set; }
		public String address { get; set; }
		public String mail { get; set; }
		public String login { get; set; }
		public String password { get; set; }
		public String image { get; set; }
		// public Boolean accountNonLocked { Get ; Set; }
		public int failedAttempt { get; set; }
		public Boolean valid { get; set; }
	
		public virtual Role role  { get; set; }

	public String stripeid { get; set; }
		public String resettoken { get; set; }


	}*/
}