using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GIAMHOADON.Utilities
{
    class FormatNumber
    {
        public static string ChuoiDao(string str)
        {
            string s = "";
            int n = str.Length;
            while (n > 0)
            {
                if (n < 3)
                {
                    s = s + str.Substring(0, n) + ",";
                    n = 0;
                }
                else
                {
                    s = s + str.Substring(n - 3, 3) + ",";
                    n = n - 3;
                }
            }

            return s;
        }

        public static string ThucHien(string s)
        {
            string flag = "";
            try
            {
                string tm = "";
                int j = s.Length;
                for (int i = s.Length - 2; i >= 0; i--)
                {
                    if (s[i] == ',')
                    {
                        tm = tm + s.Substring(i + 1, j - i - 1) + ",";
                        j = i;
                    }
                    if (i == 0)
                    {
                        tm = tm + s.Substring(i, j - i + 1);
                    }
                }
                if (tm[tm.Length - 1] == ',')
                {
                    tm = tm.Substring(0, tm.Length - 1);
                }
                flag = tm.Replace(",,", ",");

            }
            catch
            {

            }
            return flag;

        }
        public static string FormatDouble(string chuoi)
        {
            return ThucHien(ChuoiDao(chuoi));
        }

        public static double DoubleRounding(double d, int decimalPlaces)
        {
            d = d * Math.Pow(10, decimalPlaces);
            d = Math.Truncate(d);
            d = d / Math.Pow(10, decimalPlaces);
            return d;
        }
    }
}
