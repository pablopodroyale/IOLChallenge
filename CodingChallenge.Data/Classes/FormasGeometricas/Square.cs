using CodingChallenge.Data.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.FormasGeometricas
{
    public class Square : IFormaGeometrica
    {
        public Square(decimal lado) : base(lado)
        {
        }

        public override decimal CalcularArea()
        {
            return Lado * Lado;
        }

        public override decimal CalcularPerimetro()
        {
            return base.Lado * 4;
        }

      
    }
}
