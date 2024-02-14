using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate
{
    public class Translate
    {
        public async Task<string> AutoTranslationAsync(string text,
                                      string ISOlanguage = "en")
        {
            return new Parser().ParsJson(await new AccessURL().GetTextAsync(text));
        }
    }
}
