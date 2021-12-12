using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeSoftwareApplication.Search
{
    public class Searcher : ISearcher
    {
        public IList<Teacher> Search(string query, string filterOption)
        {
            var q = PrepareSearchQuery(query);
            return DoSearch(CreateSearchFilter(q, filterOption));
        }

        protected string PrepareSearchQuery(string q)
        {
            return q.Trim().ToLower();
        }

        protected string[] ParseQuery(string q)
        {
            return q.Split(' ');
        }

        protected TeachersFilter CreateSearchFilter(string query, string filterOption)
        {
            return new TeachersFilter
            {
                Query = query,
                Subject = string.IsNullOrEmpty(filterOption) ? Guid.Empty : new Guid(filterOption)
            };
        }

        protected IList<Teacher> DoSearch(TeachersFilter filter)
        {
            using (var db = ApplicationDbContext.Create())
            {
                var q = filter.Query;
                var result = db.Teachers
                    .Include("Subject")
                    .Where(t => (t.FirstName.ToLower().Contains(q) || t.MiddleName.ToLower().Contains(q) || t.LastName.ToLower().Contains(q) || t.WorkPlace.ToLower().Contains(q))
                        && (filter.Subject == Guid.Empty || (filter.Subject != Guid.Empty && t.SubjectId.Equals(filter.Subject))))
                    .OrderByDescending(t => t.Votes)
                        .ThenBy(t => t.LastName)
                        .ThenBy(t => t.FirstName);
                return result.ToList();
            }
        }

        private bool CheckTerms(string[] terms, params string[] fields)
        {
            foreach (var term in terms)
            {
                if (fields.Any(f => f.ToLower().Contains(term)))
                    return true;
            }

            return false;
        }

        private bool CheckFilter(Guid subjectId, string filterFieldValue)
        {
            if (filterFieldValue == null)
                return true;

            return subjectId.Equals(new Guid(filterFieldValue));
        }
    }
}