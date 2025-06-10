using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public abstract class Repository
    {

        public enum Category
        {
            Men,
            Women
        }

        public static Repository Get()
        {
            bool loadThroughApi = true;
            return loadThroughApi ? new ApiRepository() : new FileRepository();
        }

        public abstract Task<List<Result>?> GetResults(Category category);
        public abstract Task<List<Match>?> GetMatches(Category category, string? fifaCode=null);
    }
}
