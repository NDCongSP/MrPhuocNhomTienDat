using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace DemoPhucThinh
{
    /// <summary>
    /// Interaction logic for ucSettingsNguong.xaml
    /// </summary>
    public partial class ucSettingsNguong : System.Windows.Controls.UserControl
    {
        ConvertDataTableToList myConvert = new ConvertDataTableToList();
        ReadWriteExcel excelHelper = new ReadWriteExcel();

        public ucSettingsNguong()
        {
            InitializeComponent();
            Loaded += UcSettingsNguong_Loaded;
        }

        private void UcSettingsNguong_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        private void labPath_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    VariableGlobal.TimeInterval.PathExcel = fbd.SelectedPath;

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        labPath.Content = VariableGlobal.TimeInterval.PathExcel;
                    }));
                }
            }
        }

        private void labPathImage_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    VariableGlobal.TimeInterval.PathScreenCapture = fbd.SelectedPath;
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        labPathImage.Content = VariableGlobal.TimeInterval.PathScreenCapture;
                    }));
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Bạn có chắc chắn muốn cập nhật lại ngưỡng?", "CẢNH BÁO"
                , (MessageBoxButtons)MessageBoxButton.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                //cap nhat nguong moi vao
                foreach (var item in VariableGlobal.LimitParametter)
                {
                    switch (item.Parametters)
                    {
                        case "DuongKinh":
                            item.Min = double.TryParse(txtDuongKinhMin.Text, out double value) ? value : 0;
                            item.Max = double.TryParse(txtDuongKinhMax.Text, out value) ? value : 0;
                            break;
                        case "NDNuocNhomTrongLo":
                            item.Min = double.TryParse(txtNDNuocNhomTrongLoMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtNDNuocNhomTrongLoMax.Text, out value) ? value : 0;
                            break;
                        case "NDSauTanOngTruocKhuon":
                            item.Min = double.TryParse(txtNDNhomTruocKhuonMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtNDNhomTruocKhuonMax.Text, out value) ? value : 0;
                            break;
                        case "NDViTriThapNhatCuoiKhuon":
                            item.Min = double.TryParse(txtNDNhomTaiMiengLoMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtNDNhomTaiMiengLoMax.Text, out value) ? value : 0;
                            break;
                        case "NDSauLoXaTruocKhi":
                            item.Min = double.TryParse(txtNDNuocGiaiNhietMamMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtNDNuocGiaiNhietMamMax.Text, out value) ? value : 0;
                            break;
                        case "NDNuocMatGieng":
                            item.Min = double.TryParse(txtNDNuocMatGiengMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtNDNuocMatGiengMax.Text, out value) ? value : 0;
                            break;
                        case "NDKhongKhiTrongLo":
                            item.Min = double.TryParse(txtNDKhongKhiTrongLoMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtNDKhongKhiTrongLoMax.Text, out value) ? value : 0;
                            break;
                        case "ApLucNuocL1":
                            item.Min = double.TryParse(txtApLucNuocL1Min.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtApLucNuocL1Max.Text, out value) ? value : 0;
                            break;
                        case "VanTocSoiTitan":
                            item.Min = double.TryParse(txtVanTocSoiTitanMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtVanTocSoiTitanMax.Text, out value) ? value : 0;
                            break;
                        case "TocDoCayKhuay":
                            item.Min = double.TryParse(txtTocDoCayKhuayMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtTocDoCayKhuayMax.Text, out value) ? value : 0;
                            break;
                        case "ApKhiArgon":
                            item.Min = double.TryParse(txtApKhiArgonMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtApKhiArgonMax.Text, out value) ? value : 0;
                            break;
                        case "VanTocXuongMam":
                            item.Min = double.TryParse(txtVanTocXuongMamMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtVanTocXuongMamMax.Text, out value) ? value : 0;
                            break;
                        case "ChieuDaiPhoi":
                            item.Min = double.TryParse(txtChieuDaiPhoiMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtChieuDaiPhoiMax.Text, out value) ? value : 0;
                            break;
                        case "ThoiGianDongDac":
                            item.Min = double.TryParse(txtThoiGianDongDacMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtThoiGianDongDacMax.Text, out value) ? value : 0;
                            break;
                        case "TanSoXuongMam":
                            item.Min = double.TryParse(txtTanSoXuongMamMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtThoiGianDongDacMax.Text, out value) ? value : 0;
                            break;
                        case "TanSoBomNuoc":
                            item.Min = double.TryParse(txtTanSoBomNuocMin.Text, out value) ? value : 0;
                            item.Max = double.TryParse(txtTanSoBomNuocMax.Text, out value) ? value : 0;
                            break;
                        default:
                            break;
                    }

                    DataProvider.Instance.ExecuteNonQuery($"update limitsettings set Min = {item.Min},Max={item.Max} where Parametters = '{item.Parametters}'");
                }

                //ghi vao file excel
                excelHelper.UpdateCell("./Template/Template.xlsx", "Config", VariableGlobal.LimitParametter);

                File.WriteAllText(VariableGlobal.PathFile + "/Files/Settings.json", JsonConvert.SerializeObject(VariableGlobal.TimeInterval));

            }

            RefreshData();
        }

        #region Methods
        private void RefreshData()
        {
            VariableGlobal.LimitParametter = myConvert.ConvertDataTable<LimitSettingsModel>(DataProvider.Instance.ExecuteQuery("select * from limitsettings"));
            if (VariableGlobal.LimitParametter.Count > 0)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "DuongKinh");
                    if (res != null)
                    {
                        txtDuongKinhMin.Text = res.Min.ToString();
                        txtDuongKinhMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "NDNuocNhomTrongLo");
                    if (res != null)
                    {
                        txtNDNuocNhomTrongLoMin.Text = res.Min.ToString();
                        txtNDNuocNhomTrongLoMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "NDSauTanOngTruocKhuon");
                    if (res != null)
                    {
                        txtNDNhomTruocKhuonMin.Text = res.Min.ToString();
                        txtNDNhomTruocKhuonMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "NDViTriThapNhatCuoiKhuon");
                    if (res != null)
                    {
                        txtNDNhomTaiMiengLoMin.Text = res.Min.ToString();
                        txtNDNhomTaiMiengLoMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "NDSauLoXaTruocKhi");
                    if (res != null)
                    {
                        txtNDNuocGiaiNhietMamMin.Text = res.Min.ToString();
                        txtNDNuocGiaiNhietMamMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "NDNuocMatGieng");
                    if (res != null)
                    {
                        txtNDNuocMatGiengMin.Text = res.Min.ToString();
                        txtNDNuocMatGiengMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "NDKhongKhiTrongLo");
                    if (res != null)
                    {
                        txtNDKhongKhiTrongLoMin.Text = res.Min.ToString();
                        txtNDKhongKhiTrongLoMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "ApLucNuocL1");
                    if (res != null)
                    {
                        txtApLucNuocL1Min.Text = res.Min.ToString();
                        txtApLucNuocL1Max.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "VanTocSoiTitan");
                    if (res != null)
                    {
                        txtVanTocSoiTitanMin.Text = res.Min.ToString();
                        txtVanTocSoiTitanMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "TocDoCayKhuay");
                    if (res != null)
                    {
                        txtTocDoCayKhuayMin.Text = res.Min.ToString();
                        txtTocDoCayKhuayMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "ApKhiArgon");
                    if (res != null)
                    {
                        txtApKhiArgonMin.Text = res.Min.ToString();
                        txtApKhiArgonMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "VanTocXuongMam");
                    if (res != null)
                    {
                        txtVanTocXuongMamMin.Text = res.Min.ToString();
                        txtVanTocXuongMamMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "ChieuDaiPhoi");
                    if (res != null)
                    {
                        txtChieuDaiPhoiMin.Text = res.Min.ToString();
                        txtChieuDaiPhoiMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "ThoiGianDongDac");
                    if (res != null)
                    {
                        txtThoiGianDongDacMin.Text = res.Min.ToString();
                        txtThoiGianDongDacMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "TanSoXuongMam");
                    if (res != null)
                    {
                        txtTanSoXuongMamMin.Text = res.Min.ToString();
                        txtTanSoXuongMamMax.Text = res.Max.ToString();
                    }
                }));
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var res = (LimitSettingsModel)VariableGlobal.LimitParametter.FirstOrDefault(x => x.Parametters == "TanSoBomNuoc");
                    if (res != null)
                    {
                        txtTanSoBomNuocMin.Text = res.Min.ToString();
                        txtTanSoBomNuocMax.Text = res.Max.ToString();
                    }
                }));
            }

            Dispatcher.BeginInvoke(new Action(() =>
            {
                labPath.Content = VariableGlobal.TimeInterval.PathExcel;
            }));
            Dispatcher.BeginInvoke(new Action(() =>
            {
                labPathImage.Content = VariableGlobal.TimeInterval.PathScreenCapture;
            }));
        }
        #endregion
    }
}
