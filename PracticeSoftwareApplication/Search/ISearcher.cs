using PracticeSoftwareApplication.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeSoftwareApplication.Search
{
    public interface ISearcher
    {
        IList<Teacher> Search(string query, string filterOption);
    }
}
