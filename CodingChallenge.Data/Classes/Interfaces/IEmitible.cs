using CodingChallenge.Data.Classes.WriteStringStrategys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Interfaces
{
    public abstract class  IEmitible<T>
    {
        private readonly IStringStrategy _stringStrategy;
        public IEmitible(IStringStrategy stringStrategy)
        {
            _stringStrategy = stringStrategy;
        }
        public abstract T Emitir(List<IFormaGeometrica> formas);

        protected abstract string TraducirForma(List<IFormaGeometrica> formas);
        protected abstract string ObtenerLinea(List<IFormaGeometrica> formas);
    }

   
}
