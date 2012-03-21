using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CAPNUOCTANHOA.Utilities
{
    class Strings
    {
        public static string DoiDonViMet(double number)
        {
            //string line = String.Format("{0:0.0}", number);
            //string[] words = Regex.Split(line, "\\.");
            //if (words.Length == 2)
            //{
            //    return words[0] + "m" + words[1];
            //}
            //return words[0] + "m";
            string line = String.Format("{0:0.0}", number);
            string[] words = Regex.Split(line, "\\.");
            if (words.Length == 2)
            {
                if (words[1].Equals("0"))
                    return words[0];
                else 
                    return words[0] + "," + words[1];
            }
            return words[0] ;
        }
        public static string convertToUnSign(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD)).ToUpper();
        }

        public static DateTime stringToDate(string date, string format) {
            return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
