using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DTO_HoaDonXuat
    {
        private string hdx_Ma;
        private string ma_KH;
        private string tkht_Email;
        private DateTime hdx_NgayLap;
        private string tongTien;

        public DTO_HoaDonXuat() { }
        
        public DTO_HoaDonXuat(string hdx_Ma, string ma_KH, string tkht_Email, DateTime hdx_NgayLap, string tongTien)
        {
            this.hdx_Ma = hdx_Ma;
            this.ma_KH= ma_KH;
            this.tkht_Email = tkht_Email;
            this.hdx_NgayLap = hdx_NgayLap;
            this.tongTien = tongTien;
        }

        public string Hdx_Ma { get => hdx_Ma; set => hdx_Ma = value; }
        public string Ma_KH { get => ma_KH; set => ma_KH = value; }
        public string Tkht_Email { get => tkht_Email; set => tkht_Email = value; }
        public DateTime Hdx_NgayLap { get => hdx_NgayLap; set => hdx_NgayLap = value; }
        public string TongTien { get => tongTien; set => tongTien = value; }

        /*public string HDX_Ma { get; set; }
public string MA_KH { get; set; }
public string TKHT_Email { get; set; }
public DateTime HDX_NgayLap { get; set; }*/
    }
}
