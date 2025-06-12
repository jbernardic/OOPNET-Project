using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace DataLayer.Repository
{
    public class FileRepository(UserSettings.Category category) : Repository(category)
    {
        
        //private void GetData()
        //{
        //    var assembly = Assembly.GetExecutingAssembly();

        //    using Stream? stream = assembly.GetManifestResourceStream(resourceName);
        //    if (stream == null)
        //        throw new FileNotFoundException($"Resource '{resourceName}' not found.");

        //    using var reader = new StreamReader(stream);
        //    return reader.ReadToEnd();
        //}

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
