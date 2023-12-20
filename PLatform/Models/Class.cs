using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PLatform.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsAvailable { get; set; }

        public string VidSrc { get; set; }

        public string Training { get; set; }

        public Grade Grade { get; set; }
        public int GradeId { get; set; }


    }
}