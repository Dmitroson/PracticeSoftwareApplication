using PracticeSoftwareApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.DomainModels
{
    public class Teacher : IEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Guid SubjectId { get; set; }

        public string WorkPlace { get; set; }

        public string ImagePath { get; set; }

        public long Votes { get; set; }

        public Subject Subject { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}