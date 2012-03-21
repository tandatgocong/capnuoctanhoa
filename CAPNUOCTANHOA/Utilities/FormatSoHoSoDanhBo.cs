using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAPNUOCTANHOA.Utilities
{
    class FormatSoHoSoDanhBo
    {
        public static string sohoso(string _sohoso)
        {
            _sohoso = _sohoso.Insert(4, ".");
            _sohoso = _sohoso.Insert(9, ".");
            return _sohoso;
        }
        public static string sodanhbo(string _danhbo)
        {
            if (_danhbo.Length == 11)
            {
                _danhbo = _danhbo.Insert(4, "-");
                _danhbo = _danhbo.Insert(8, "-");
               
            }
            return _danhbo;
        }
        public static string sodanhbo(string _danhbo, string kytu)
        {
            _danhbo = _danhbo.Trim();
            if (_danhbo.Length >8)
            {
                _danhbo = _danhbo.Insert(4, kytu);
                _danhbo = _danhbo.Insert(8, kytu);

            }
            return _danhbo;
        }

        public static string phienlotrinh(string _lotrinh, string kytu)
        {
            _lotrinh = _lotrinh.Replace(" ","");
            if (_lotrinh.Length>6)
            {
                _lotrinh = _lotrinh.Insert(2, kytu);
                _lotrinh = _lotrinh.Insert(5, kytu);

            }
            return _lotrinh;
        }

    }
}
