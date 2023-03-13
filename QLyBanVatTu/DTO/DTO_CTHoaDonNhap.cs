using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_CTHoaDonNhap
    {
        private string hdn_Ma;
        private string hh_Ma;
        private int soLuongNhap;
        private float donGiaNhap;

        public DTO_CTHoaDonNhap() 
        {
        }
        public DTO_CTHoaDonNhap(string hdn_Ma, string hh_Ma, int soLuongNhap, float donGiaNhap)
        {
            this.hdn_Ma = hdn_Ma;
            this.hh_Ma = hh_Ma;
            this.soLuongNhap = soLuongNhap;
            this.donGiaNhap = donGiaNhap;
        }

        public string Hdn_Ma { get => hdn_Ma; set => hdn_Ma = value; }
        public string Hh_Ma { get => hh_Ma; set => hh_Ma = value; }
        public int SoLuongNhap { get => soLuongNhap; set => soLuongNhap = value; }
        public float DonGiaNhap { get => donGiaNhap; set => donGiaNhap = value; }
        /*public string HDN_Ma { get; set; }
public string HH_Ma { get; set; }
public int SoLuongNhap { get; set; }
public float DonGiaNhap { get; set; }*/
    }
}
