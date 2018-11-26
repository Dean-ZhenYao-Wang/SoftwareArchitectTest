using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ZYW.CommonMVC
{
    public class TrimToDBCModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object value = base.BindModel(controllerContext, bindingContext);
            if (value is string)
            {
                string strValue = (string)value;
                string value2 = ToDBC(strValue).Trim();
                return value2;
            }
            else
            {
                return value;
            }
        }
        /// <summary>
        /// Full Angle Half Angle Function (DBC Case)
        /// </summary>
        /// <param name="input">Arbitrary string</param>
        /// <returns>Half angle string</returns>
        /// <remarks>
        /// Full-angle space is 12288 and half-angle space is 32.
        /// The corresponding relationship between other characters'half-angle (33-126) and full-angle (65281-65374) is that the difference is 65248.
        /// </remarks>
        private static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                {
                    c[i] = (char)(c[i] - 65248);
                }
            }
            return new string(c);
        }
    }
}
