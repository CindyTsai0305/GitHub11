using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHR.Common
{
    public class StringTool
    {
        public static string MaskString(string charText, int length)
        {
            string result = string.Empty;
            for (int i = 0; i < length; i++)
            {
                result += charText;
            }
            return result;
        }
    }
}
