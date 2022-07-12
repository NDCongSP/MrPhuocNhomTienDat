using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoPhucThinh
{
    public class ModelParametters
    {
        //các biến lưu giá trị của các tag để log DB
        public string DateTime { get; set; }
        public double TNuocNhomTrongLo { get; set; }
        public double TSauTanOngTruocKhuon { get; set; }
        public double TViTriThapNhatCuoiKhuon { get; set; }
        public double TNuocGiaiNhietMam { get; set; }
        public double TSauLoXaTruocKhi { get; set; }
        public double TKhongKhiTrongLo { get; set; }
        public string MacNhom { get; set; }
        public string DuongKinh { get; set; }
        public double ApLucNuocL1 { get; set; }
        public double VanTocSoiTitan { get; set; }
        public double TocDoCayKhuay { get; set; }
        public double ApKhiArgon { get; set; }
        public double VanTocXuongMam { get; set; }
        public double ChieuDaiPhoi { get; set; }
        public double ThoiGianDongDac { get; set; }
        public double TanSoXuongMam { get; set; }
        public double TanSoBomNuoc { get; set; }

        public ModelParametters()
        {

        }

        public ModelParametters(DataRow row)
        {
            this.DateTime = row["DateTime"].ToString();
            this.TNuocNhomTrongLo = !string.IsNullOrEmpty(row["NhietDoNuocNhomTrongLo"].ToString()) ? Math.Round(Convert.ToDouble(row["NhietDoNuocNhomTrongLo"]), 2) : 0;
            this.TSauTanOngTruocKhuon = !string.IsNullOrEmpty(row["NhietDoSauTanOngTruocKhuon"].ToString()) ? Math.Round(Convert.ToDouble(row["NhietDoSauTanOngTruocKhuon"]), 2) : 0;
            this.TViTriThapNhatCuoiKhuon = !string.IsNullOrEmpty(row["NhietDoViTriThapNhatCuoiKhuon"].ToString()) ? Math.Round(Convert.ToDouble(row["NhietDoViTriThapNhatCuoiKhuon"]), 2) : 0;

            this.TNuocGiaiNhietMam = !string.IsNullOrEmpty(row["NhietDoNuocGiaiNhietMam"].ToString()) ? Math.Round(Convert.ToDouble(row["NhietDoNuocGiaiNhietMam"]), 2) : 0;
            this.TSauLoXaTruocKhi = !string.IsNullOrEmpty(row["NhietDoSauLoXaTruocKhi"].ToString()) ? Math.Round(Convert.ToDouble(row["NhietDoSauLoXaTruocKhi"]), 2) : 0;
            this.TKhongKhiTrongLo = !string.IsNullOrEmpty(row["NhietDoKhongKhiTrongLo"].ToString()) ? Math.Round(Convert.ToDouble(row["NhietDoKhongKhiTrongLo"]), 2) : 0;
            this.MacNhom = row["MacNhom"].ToString();
            this.DuongKinh = row["DuongKinh"].ToString();
            this.ApLucNuocL1 = !string.IsNullOrEmpty(row["ApLucNuocL1"].ToString()) ? Math.Round(Convert.ToDouble(row["ApLucNuocL1"]), 2) : 0;
            this.VanTocSoiTitan = !string.IsNullOrEmpty(row["VanTocSoiTitan"].ToString()) ? Math.Round(Convert.ToDouble(row["VanTocSoiTitan"]), 2) : 0;
            this.TocDoCayKhuay = !string.IsNullOrEmpty(row["TocDoCayKhuay"].ToString()) ? Math.Round(Convert.ToDouble(row["TocDoCayKhuay"]), 2) : 0;
            this.ApKhiArgon = !string.IsNullOrEmpty(row["ApKhiArgon"].ToString()) ? Math.Round(Convert.ToDouble(row["ApKhiArgon"]), 2) : 0;
            this.VanTocXuongMam = !string.IsNullOrEmpty(row["VanTocXuongMam"].ToString()) ? Math.Round(Convert.ToDouble(row["VanTocXuongMam"]), 2) : 0;
            this.ChieuDaiPhoi = !string.IsNullOrEmpty(row["ChieuDaiPhoi"].ToString()) ? Math.Round(Convert.ToDouble(row["ChieuDaiPhoi"]), 2) : 0;
            this.ThoiGianDongDac = !string.IsNullOrEmpty(row["ThoiGianDongDac"].ToString()) ? Math.Round(Convert.ToDouble(row["ThoiGianDongDac"]), 2) : 0;
            this.TanSoXuongMam = !string.IsNullOrEmpty(row["TanSoXuongMam"].ToString()) ? Math.Round(Convert.ToDouble(row["TanSoXuongMam"]), 2) : 0;
            this.TanSoBomNuoc = !string.IsNullOrEmpty(row["TanSoBomNuoc"].ToString()) ? Math.Round(Convert.ToDouble(row["TanSoBomNuoc"]), 2) : 0;

        }
    }
}
