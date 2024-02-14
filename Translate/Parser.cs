using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translate
{
    public class Parser
    {
        public string ParsJson(string content)
        {
            dynamic json = JsonConvert.DeserializeObject(content);
            return json[0][0][0].ToString();
        }

    }
}
