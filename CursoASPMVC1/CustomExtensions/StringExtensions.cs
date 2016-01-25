using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//namespace CursoASPMVC1.CustomExtensions
//{

//}

public static class StringExtensions
{
    public static string SecureSubString(this String str, int startIndex, int length)
    {
        string subStr = String.Empty;
        if (startIndex < str.Length)
        {
            if (str.Length >= startIndex + length)
            {
                subStr = str.Substring(startIndex: startIndex, length: length);
            }
            else
            {
                subStr = str.Substring(startIndex: startIndex, length: str.Length - startIndex);
            }
        }

        return subStr;
    }
}