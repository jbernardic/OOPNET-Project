using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class FileRepository(UserSettings.Category category) : Repository(category)
    {
        public override Task<List<Match>?> GetMatches(string? fifaCode = null)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Result>?> GetResults()
        {
            throw new NotImplementedException();
        }
    }
}
