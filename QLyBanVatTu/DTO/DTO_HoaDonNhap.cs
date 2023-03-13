using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    internal class DTO_HoaDonNhap
    {
        private string hdn_Ma;
        private string ncc_Ma;
        private string tkht_Email;
        private DateTime hdn_NgayLap;

        public DTO_HoaDonNhap() { }
        public DTO_HoaDonNhap(string hdn_Ma, string ncc_Ma, string tkht_Email, DateTime hdn_NgayLap)
        {
            this.hdn_Ma = hdn_Ma;
            this.ncc_Ma = ncc_Ma;
            this.tkht_Email = tkht_Email;
            this.hdn_NgayLap = hdn_NgayLap;
        }

        public string Hdn_Ma { get => hdn_Ma; set => hdn_Ma = value; }
        public string Ncc_Ma { get => ncc_Ma; set => ncc_Ma = value; }
        public string Tkht_Email { get => tkht_Email; set => tkht_Email = value; }
        public DateTime Hdn_NgayLap { get => hdn_NgayLap; set => hdn_NgayLap = value; }
        /*public string HDN_Ma { get; set; }
public string NCC_Ma { get; set; }
public string TKHT_Email { get; set; }
public DateTime HDN_NgayNhap { get; set; }*/
    }
}
