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
        public string GetImpresionStr(List<IFormaGeometrica> formas, int idioma)
        {
            //Recupero el lenguaje para volverselo a setear
            CultureInfo cultureInfo = LenguageHelper.GetCurrentCulture();
            LenguageHelper.SwitchThreadLenguage(idioma);
            string ret = new EmitibleString(_stringStrategy).Emitir(formas);
            //Le vuelvo a setear el lenguaje
            LenguageHelper.SetCultureInfo(cultureInfo);
            return ret;
        }

        /// <summary>
        /// Escribe una oracion con este modelo:
        /// x forma/s Area xxx Perimetro xxx
        /// </summary>
        /// <param name="cantidad"></param>
        /// <param name="area"></param>
        /// <param name="perimetro"></param>
        /// <param name="tipo"></param>
        /// <param name="idioma"></param>
        /// <returns></returns>
        private string ObtenerLinea(List<IFormaGeometrica> formas)
        {
            if (formas.Count() > 0)
            {
                return $"{formas.Count()} {FunctionHelper.UppercaseFirst(TraducirForma(formas))} | {Resources.strings.Area} {formas.Sum(x => x.CalcularArea()):#.##} | { FunctionHelper.UppercaseFirst(Resources.strings.Perimeter)} {formas.Sum(x => x.CalcularPerimetro()):#.##} ";
            }

            return string.Empty;
        }

        private string TraducirForma(List<IFormaGeometrica> formas)
        {
            var clas = formas.First().GetType().Name.ToString();
            /* Reference to your resources class -- may be named differently in your case */
            ResourceManager MyResourceClass = new ResourceManager(typeof(Resources.strings));

            ResourceSet resourceSet = MyResourceClass.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            IDictionaryEnumerator dictNumerator = resourceSet.GetEnumerator();
            string res = null;
            // Get all string resources
            while (dictNumerator.MoveNext() && res == null)
            {
                // Only string resources
                if (dictNumerator.Value is string)
                {
                    var key = (string)dictNumerator.Key;
                    if (key == clas)
                    {
                        res = (string)dictNumerator.Value;
                    }
                }
            }
            return formas.Count() == 1 ? res : string.Format(res + "{0}", "s");
        }
    }
}
