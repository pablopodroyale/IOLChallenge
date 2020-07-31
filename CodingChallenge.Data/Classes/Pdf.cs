using CodingChallenge.Data.Classes.Interfaces;
using CodingChallenge.Data.Classes.WriteStringStrategys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class Pdf : IEmitible<Pdf>
    {
        public Pdf(IStringStrategy stringStrategy) : base(stringStrategy)
        {
        }


        public override Pdf Emitir(List<IFormaGeometrica> formas)
        {
            throw new NotImplementedException();
        }

        protected override string ObtenerLinea(List<IFormaGeometrica> formas)
        {
            throw new NotImplementedException();
        }

        protected override string TraducirForma(List<IFormaGeometrica> formas)
        {
            throw new NotImplementedException();
        }
    }
}
