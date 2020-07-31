using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.WriteStringStrategys
{
    public interface IStringStrategy
    {
        string BreakLine();
        string WriteLine(string text);
        string WriteHeader(string text);
    }
}
