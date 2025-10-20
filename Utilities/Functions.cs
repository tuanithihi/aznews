using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aznews.Utilities
{
    public class Functions
    {
        public static string  TitleGeneration(string type, string? title, long id)
        {
            return type + "-" + SlugGenerator.SlugGenerator.GenerateSlug(title) + "-" + id.ToString() + ".html";
        }
    }
}