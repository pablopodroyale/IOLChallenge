using CodingChallenge.Data.Classes.Enum;
using CodingChallenge.Data.Classes.Interfaces;
using CodingChallenge.Data.Classes.Utils;
using CodingChallenge.Data.Classes.WriteStringStrategys;
using CodingChallenge.Data.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class EmiFactory
    {
        private readonly IStringStrategy _stringStrategy;
        public EmiFactory(IStringStrategy stringStrategy)
        {
            _stringStrategy = stringStrategy;
        }
        public static IEmitible<string> GetEmitible()
        {

            return null;
        }

        /// <summary>
        /// Este seria un metodo generico para devolver el tipo solicitado de IEmitible como string, PDf o Email, etc..
        /// Tendria que cambiar la firma de imprimir y de los tests
        /// </summary>
        /// <param name="formas"></param>
        /// <param name="idioma"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEmitible<T> GetImpresionGeneric<T>(List<IFormaGeometrica> formas, int idioma, T type)
        {
            IEmitible<T> emitible = null;
            //Visual studio crashea evaluando generics 
            //switch (type)
            //{
            //    default:
            //}

            return emitible;

        }

        /// <summary>
        /// Este seria un metodo provisorio. Deberia devolver un emitible del Tipo solicitado: Email, Pdf, String..etc
        /// </summary>
        /// <param name="formas"></param>
        /// <param name="idioma"></param>
        /// <returns></returns>
        public string GetImpresionStr(List<IFormaGeometrica> formas)
        {
           return  new EmitibleString(_stringStrategy).Emitir(formas);
        }
             
    }
}
