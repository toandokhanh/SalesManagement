using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTHoaDonXuat
    {
        private string hdx_Ma;
        private string hh_Ma;
        private int soLuongXuat;
        private float donGiaNhap;

        public DTO_CTHoaDonXuat() { }
        public DTO_CTHoaDonXuat(string hdx_Ma, string hh_Ma, int soLuongXuat, float donGiaNhap)
        {
            this.hdx_Ma = hdx_Ma;
            this.hh_Ma = hh_Ma;
            this.soLuongXuat = soLuongXuat;
            this.donGiaNhap = donGiaNhap;
        }

        public string Hdx_Ma { get => hdx_Ma; set => hdx_Ma = value; }
        public string Hh_Ma { get => hh_Ma; set => hh_Ma = value; }
        public int SoLuongXuat { get => soLuongXuat; set => soLuongXuat = value; }
        public float DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }

        /*public string HDX_Ma { get; set; }
public string HH_Ma { get; set; }
public int SoLuongXuat { get; set; }
public float DonGiaNhap { get; set; }*/
    }
}
