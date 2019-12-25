using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class Dien
    {
        string macongtodien;
        string chisoDau;
        string chisoCuoi;
        string ngayGhi;
        string tieuThu;
        float donGia;
        long thanhTien;
        public string TieuThu
        {
            get { return tieuThu; }
            set { tieuThu = value; }
        }
        public string NgayGhi
        {
            get { return ngayGhi; }
            set { ngayGhi = value; }
        }
        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }


        public long ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
        public string ChisoDau
        {
            get { return chisoDau; }
            set { chisoDau = value; }
        }

        public string ChisoCuoi
        {
            get { return chisoCuoi; }
            set { chisoCuoi = value; }

        }

        public string Macongtodien
        {
            get
            {
                return macongtodien;
            }

            set
            {
                macongtodien = value;
            }
        }
    }
}