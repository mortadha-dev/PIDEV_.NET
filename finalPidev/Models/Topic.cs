using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finalPidev.Models
{
    public class Topic
    {

        public int idTopic { get; set; }
        public String title { get; set; }
        public String content { get; set; }
        public DateTime creationDate { get; set; }
        public int numberViews { get; set; }
        public User userId { get; set; }
        public int? idUser { get; set; }
        
    }
}