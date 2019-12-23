using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class PhongSV
    {
        string maSV;
        string maPhong;
        string ngayBD;
        string ngayKT;

        public string MaSV
        {
            get
            {
                return maSV;
            }

            set
            {
                maSV = value;
            }
        }

        public string MaPhong
        {
            get
            {
                return maPhong;
            }

            set
            {
                maPhong = value;
            }
        }

        public string NgayBD
        {
            get
            {
                return ngayBD;
            }

            set
            {
                ngayBD = value;
            }
        }
        public string NgayKT
        {
            get
            {
                return ngayKT;
            }

            set
            {
                ngayKT = value;
            }
        }
    }
}