using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.DomainModels
{
    public class Subject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
    }
}