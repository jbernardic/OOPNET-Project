using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class FileRepository : Repository
    {
        public override Task<List<Match>?> GetMatches(Category category, string? fifaCode = null)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Result>?> GetResults(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
