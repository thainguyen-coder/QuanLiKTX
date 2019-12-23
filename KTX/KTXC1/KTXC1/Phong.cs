using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class Phong
    {
        string maPhong;

        public string MaPhong
        {
            get { return maPhong; }
            set { maPhong = value; }
        }

        string tinhTrangPhong;

        public string TinhTrangPhong
        {
            get { return tinhTrangPhong; }
            set { tinhTrangPhong = value; }
        }

        int soLuongSV;

        public int SoLuongSV
        {
            get { return soLuongSV; }
            set { soLuongSV = value; }
        }
    }
}