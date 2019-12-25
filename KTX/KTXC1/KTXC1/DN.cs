using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KTXC1
{
    public class DN
    {
        string maCongToNuoc;

        public string MaCongToNuoc
        {
            get { return maCongToNuoc; }
            set { maCongToNuoc = value; }
        }
        string chisoDau;

        public string ChisoDau
        {
            get { return chisoDau; }
            set { chisoDau = value; }
        }
        string chisoCuoi;

        public string ChisoCuoi
        {
            get { return chisoCuoi; }
            set { chisoCuoi = value; }
        }
        string ngayGhi;

        public string NgayGhi
        {
            get { return ngayGhi; }
            set { ngayGhi = value; }
        }
        string tieuThu;

        public string TieuThu
        {
            get { return tieuThu; }
            set { tieuThu = value; }
        }
        float donGia;

        public float DonGia
        {
            get { return donGia; }
            set { donGia = value; }
        }
        long thanhTien;

        public long ThanhTien
        {
            get { return thanhTien; }
            set { thanhTien = value; }
        }
    }
}