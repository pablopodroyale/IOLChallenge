using CodingChallenge.Data.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.FormasGeometricas
{
    public class Trapeze : IFormaGeometrica
    {
        public Trapeze(decimal lado) : base(lado)
        {
        }

        public override decimal CalcularArea()
        {
            throw new NotImplementedException();
        }

        public override decimal CalcularPerimetro()
        {
            throw new NotImplementedException();
        }
    }
}
