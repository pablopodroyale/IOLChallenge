using CodingChallenge.Data.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.FormasGeometricas
{
    public class TriangleEq : IFormaGeometrica
    {
        public TriangleEq(decimal lado) : base(lado)
        {
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * Lado * Lado;
           
        }

        public override decimal CalcularPerimetro()
        {
            return Lado * 3;
        }
    }
}
