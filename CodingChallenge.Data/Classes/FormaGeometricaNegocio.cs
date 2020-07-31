/*
 * Refactorear la clase para respetar principios de programación orientada a objetos. Qué pasa si debemos soportar un nuevo idioma para los reportes, o
 * agregar más formas geométricas?
 *
 * Se puede hacer cualquier cambio que se crea necesario tanto en el código como en los tests. La única condición es que los tests pasen OK.
 *
 * TODO: Implementar Trapecio/Rectangulo, agregar otro idioma a reporting.
 * */

using CodingChallenge.Data.Classes.Interfaces;
using CodingChallenge.Data.Classes.Utils;
using CodingChallenge.Data.Classes.WriteStringStrategys;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public class FormaGeometricaNegocio
    {


        public static string Imprimir(List<IFormaGeometrica> formas, int idioma)
        {
            //Recupero el lenguaje para volverselo a setear
            CultureInfo cultureInfo = LenguageHelper.GetCurrentCulture();
            LenguageHelper.SwitchThreadLenguage(idioma);
            var ret = new EmiFactory(new HtmlStringStrategy()).GetImpresionStr(formas);
            //Le vuelvo a setear el lenguaje
            LenguageHelper.SetCultureInfo(cultureInfo);
            return ret;
         
        }

      
    }
}
