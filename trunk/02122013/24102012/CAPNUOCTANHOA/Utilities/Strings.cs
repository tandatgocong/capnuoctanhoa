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
            //string line = String.Format('{0:0.0}', number);
            //string[] words = Regex.Split(line, '\\.');
            //if (words.Length == 2)
            //{
            //    return words[0] + 'm' + words[1];
            //}
            //return words[0] + 'm';
            string line = String.Format("{0:0.0}", number);
            string[] words = Regex.Split(line, "\\.");
            if (words.Length == 2)
            {
                if (words[1].Equals('0'))
                    return words[0];
                else
                    return words[0] + ',' + words[1];
            }
            return words[0];
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

        public static DateTime stringToDate(string date, string format)
        {
            return DateTime.ParseExact(date, format, System.Globalization.CultureInfo.InvariantCulture);
        }

        private static char[] tcvnchars = { 'µ', '¸', '¶', '·', '¹',  '¨', '»', '¾', '¼', '½', 'Æ','©', 'Ç', 'Ê', 'È', 'É', 'Ë', '®', 'Ì', 'Ð', 'Î', 'Ï', 'Ñ', 
        'ª', 'Ò', 'Õ', 'Ó', 'Ô', 'Ö', 
        '×', 'Ý', 'Ø', 'Ü', 'Þ', 
        'ß', 'ã', 'á', 'â', 'ä', 
        '«', 'å', 'è', 'æ', 'ç', 'é', 
        '¬', 'ê', 'í', 'ë', 'ì', 'î', 
        'ï', 'ó', 'ñ', 'ò', 'ô', 
        '­', 'õ', 'ø', 'ö', '÷', 'ù', 
        'ú', 'ý', 'û', 'ü', 'þ', 
        '¡', '¢', '§', '£', '¤', '¥', '¦'
    };

        private static char[] unichars = {
        'à', 'á', 'ả', 'ã', 'ạ', 
        'ă', 'ằ', 'ắ', 'ẳ', 'ẵ', 'ặ', 
        'â', 'ầ', 'ấ', 'ẩ', 'ẫ', 'ậ', 
        'đ', 'è', 'é', 'ẻ', 'ẽ', 'ẹ', 
        'ê', 'ề', 'ế', 'ể', 'ễ', 'ệ', 
        'ì', 'í', 'ỉ', 'ĩ', 'ị', 
        'ò', 'ó', 'ỏ', 'õ', 'ọ', 
        'ô', 'ồ', 'ố', 'ổ', 'ỗ', 'ộ', 
        'ơ', 'ờ', 'ớ', 'ở', 'ỡ', 'ợ', 
        'ù', 'ú', 'ủ', 'ũ', 'ụ', 
        'ư', 'ừ', 'ứ', 'ử', 'ữ', 'ự', 
        'ỳ', 'ý', 'ỷ', 'ỹ', 'ỵ', 
        'Ă', 'Â', 'Đ', 'Ê', 'Ô', 'Ơ', 'Ư'
    };

        private static char[] convertTable;

        static Strings()
        {
            convertTable = new char[256];
            for (int i = 0; i < 256; i++)
                convertTable[i] = (char)i;
            for (int i = 0; i < tcvnchars.Length; i++)
                convertTable[tcvnchars[i]] = unichars[i];
        }

        public static string TCVN3ToUnicode(string value)
        {
            char[] chars = value.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
                if (chars[i] < (char)256)
                    chars[i] = convertTable[chars[i]];
            return new string(chars);
        }
      
    }
}