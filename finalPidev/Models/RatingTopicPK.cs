using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace finalPidev.Models
{
    public class RatingTopicPK
    {
        public User user { get; set; }
        [Key, Column(Order = 0)]
        public int idUser { get; set; }
        public Topic topic { get; set; }
        [Key, Column(Order = 1)]
        public int idTopic { get; set; }
    }
}