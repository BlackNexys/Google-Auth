using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Google_Auth.Models
{
    public class Banana
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string placeOfOrigin { get; set; }

        public ApplicationUser ApplicationUserID { get; set; }
    }
}