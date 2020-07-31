using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.WriteStringStrategys
{
    class HtmlStringStrategy : IStringStrategy
    {
        public string BreakLine()
        {
            return "<br/>";
        }

        public char WriteHeader(string text)
        {
            throw new NotImplementedException();
        }

        public string WriteLine(string text)
        {
            return string.Format("<h1>" + "{0}" + "</h1>",text);
        }
    }
}
