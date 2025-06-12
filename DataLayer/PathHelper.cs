using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public abstract class PathHelper
    {
        public static string GetRelativePath(string path)
        {
            var exePath = (Assembly.GetEntryAssembly()?.Location) ?? throw new InvalidOperationException("Entry assembly is null. This might happen in some environments like unit tests or plugins.");
            var exeDirectory = Path.GetDirectoryName(exePath);
            return Path.Combine(exeDirectory!, path);
        }
    }
}
