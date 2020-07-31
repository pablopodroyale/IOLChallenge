using CodingChallenge.Data.Classes.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Utils
{
    public static class LenguageHelper
    {
        public static void SwitchThreadLenguage(int lenguage)
        {
            switch (lenguage)
            {
                case (int)LenguageEnum.castellano:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");
                    break;
                case (int)LenguageEnum.ingles:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                    break;
                default:
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("es-ES");
                    break;
            }

        }

        public static CultureInfo GetCurrentCulture()
        {
            return Thread.CurrentThread.CurrentCulture;
        }

        public static void SetCultureInfo(CultureInfo cultureInfo)
        {
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
        }
    }
}
