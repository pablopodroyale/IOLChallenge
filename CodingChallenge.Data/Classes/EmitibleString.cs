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
    public class EmitibleString : IEmitible<string>
    {
        private readonly IStringStrategy _stringStrategy;
        public EmitibleString(IStringStrategy stringStrategy):base(stringStrategy)
        {
            _stringStrategy = stringStrategy;
        }



        public override string Emitir(List<IFormaGeometrica> formas)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                sb.Append(_stringStrategy.WriteLine(Resources.strings.Empty_List));
            }
            else
            {
                // Hay por lo menos una forma
                // HEADER
                sb.Append(_stringStrategy.WriteLine(Resources.strings.Report_Header));
                var shapesInList = formas.GroupBy(x => x.GetType().ToString()).ToList();
                foreach (var item in shapesInList)
                {

                    //Agrupo por lista de formas
                    var forms = formas.Where(f => f.GetType().Name.ToString() == item.Key.Split('.').ToList().Last()).ToList();

                    sb.Append(ObtenerLinea(forms));
                    sb.Append(_stringStrategy.BreakLine());
                }

                // FOOTER
                sb.Append($"{Resources.strings.Report_Footer + ":"}{_stringStrategy.BreakLine()}{formas.Count()} {Resources.strings.Shapes} ");
                sb.Append((FunctionHelper.UppercaseFirst(Resources.strings.Perimeter)) + " " + (formas.Sum(x => x.CalcularPerimetro())).ToString("#.##") + " ");
                sb.Append(FunctionHelper.UppercaseFirst(Resources.strings.Area) + " " + (formas.Sum(x => x.CalcularArea())).ToString("#.##"));
            }
            return sb.ToString();
        }

        protected override string TraducirForma(List<IFormaGeometrica> formas)
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

        protected override string ObtenerLinea(List<IFormaGeometrica> formas)
        {
            if (formas.Count() > 0)
            {
                return $"{formas.Count()} {FunctionHelper.UppercaseFirst(TraducirForma(formas))} | {Resources.strings.Area} {formas.Sum(x => x.CalcularArea()):#.##} | { FunctionHelper.UppercaseFirst(Resources.strings.Perimeter)} {formas.Sum(x => x.CalcularPerimetro()):#.##} ";
            }

            return string.Empty;
        }

       
    }
}
