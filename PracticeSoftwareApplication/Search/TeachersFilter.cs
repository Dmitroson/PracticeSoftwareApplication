using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.Search
{
    public class TeachersFilter
    {
        public string Query { get; set; }

        public Guid Subject { get; set; }
    }
}