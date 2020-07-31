using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Interfaces
{
    public abstract class IFormaGeometrica
    {
        public decimal Lado { get; set; }

        public  abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public IFormaGeometrica(decimal lado)
        {
            Lado = lado;
        }
      
    }
}
