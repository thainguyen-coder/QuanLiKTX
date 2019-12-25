using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class Hoadon
    {
        string maHD;
        string maNV;
        string maPhong;
        string maCongToDien;
        string maCongToNuoc;
        long tongTien;
        string ngayGhi;

        public string MaHD
        {
            get
            {
                return maHD;
            }

            set
            {
                maHD = value;
            }
        }

        public string MaNV
        {
            get
            {
                return maNV;
            }

            set
            {
                maNV = value;
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

        public string MaCongToDien
        {
            get
            {
                return maCongToDien;
            }

            set
            {
                maCongToDien = value;
            }
        }

        public string MaCongToNuoc
        {
            get
            {
                return maCongToNuoc;
            }

            set
            {
                maCongToNuoc = value;
            }
        }

        public long TongTien
        {
            get
            {
                return tongTien;
            }

            set
            {
                tongTien = value;
            }
        }

        public string NgayGhi
        {
            get
            {
                return ngayGhi;
            }

            set
            {
                ngayGhi = value;
            }
        }
    }
}