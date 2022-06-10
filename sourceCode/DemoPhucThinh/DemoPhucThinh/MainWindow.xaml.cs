using EasyScada.Core;
using EasyScada.Wpf.Controls;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using Path = System.IO.Path;

namespace DemoPhucThinh
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private System.Timers.Timer _timer = new System.Timers.Timer();
        private System.Timers.Timer _timerShowTime = new System.Timers.Timer();

        private ModelParametters parametterLocal = new ModelParametters();
        private DateTime startTime, stopTime;
        private TimeSpan timeLog;
        private int queryResult = 0;
        private bool isStated = false;

        private string timeStartExport = "";
        private bool capScreenAction = false;
        private double capScreenInterval = 3;//đơn vị (min)
        private DateTime startTimeCapture, stopTimeCapture;
        private TimeSpan timeCapture;

        private ConvertDataTableToList myConvert = new ConvertDataTableToList();
        private ReadWriteExcel excelHelper = new ReadWriteExcel();

        IEasyDriverConnector Connector { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            new UserControl1();

            VariableGlobal.PathFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //File.WriteAllText(Path.Combine(VariableGlobal.PathFile, "log.txt"), VariableGlobal.PathFile);

            using (StreamReader r = new StreamReader(VariableGlobal.PathFile + "/Files/Settings.json"))
            {
                string json = r.ReadToEnd();
                VariableGlobal.TimeInterval = JsonConvert.DeserializeObject<ModelTimeInterval>(json);
            }

            #region đăng ký sự kiện tagValueChanged của các tag dòng motor để nó ghi nhận thời gian máy chạy máy dừng, dựa vào dòng của động cơ

            Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();

            parametter.Start();
            Connector.Started += MainWindow_Started;

            #endregion
            startTime = stopTime = DateTime.Now;
            timeLog = startTime - stopTime;

            _timer.Interval = VariableGlobal.TimeInterval.ThoiGianLogData * 1000;
            _timer.Elapsed += _timerElapsed;
            _timer.Enabled = true;

            _timerShowTime.Interval = 100;
            _timerShowTime.Elapsed += (s, o) =>
            {
                _timerShowTime.Enabled = false;

                Dispatcher.BeginInvoke(new Action(() =>
                {
                    labTime.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                }));

                #region Chup anh man hinh
                if (capScreenAction)
                {
                    stopTimeCapture = DateTime.Now;
                    timeCapture = stopTimeCapture - startTimeCapture;

                    if (timeCapture.TotalMinutes >= capScreenInterval)
                    {
                        var bitmap = CS();

                        if (Directory.Exists(VariableGlobal.TimeInterval.PathScreenCapture))
                        {
                            bitmap.Save($"{VariableGlobal.TimeInterval.PathScreenCapture}\\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_CaptureScreen.png", ImageFormat.Png);
                        }
                        else
                        {
                            Directory.CreateDirectory(VariableGlobal.TimeInterval.PathScreenCapture);
                            bitmap.Save($"{VariableGlobal.TimeInterval.PathScreenCapture}\\{DateTime.Now.ToString("yyyyMMdd_HHmmss")}_CaptureScreen.png", ImageFormat.Png);
                        }

                        startTimeCapture = DateTime.Now;
                    }
                }
                #endregion

                _timerShowTime.Enabled = true;
            };
            _timerShowTime.Enabled = true;
        }

        private void MainWindow_Started(object sender, EventArgs e)
        {
            TSauLoXaTruocKhi_ValueChanged(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauLoXaTruocKhi/Pv"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauLoXaTruocKhi/Pv")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauLoXaTruocKhi/Pv").Value));

            TNuocGiaiNhietMam_ValueChanged(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocGiaiNhietMam/Pv"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocGiaiNhietMam/Pv")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocGiaiNhietMam/Pv").Value));

            TKhongKhiTrongLo_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TKhongKhiTrongLo/Pv"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TKhongKhiTrongLo/Pv")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TKhongKhiTrongLo/Pv").Value));

            TNuocNhomTrongLo_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocNhomTrongLo/Pv"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocNhomTrongLo/Pv")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocNhomTrongLo/Pv").Value));

            TSauTanOngTruocKhuon_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauTanOngTruocKhuon/Pv"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauTanOngTruocKhuon/Pv")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauTanOngTruocKhuon/Pv").Value));

            TViTriThapNhatCuoiKhuon_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TViTriThapNhatCuoiKhuon/Pv"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TViTriThapNhatCuoiKhuon/Pv")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TViTriThapNhatCuoiKhuon/Pv").Value));
            //Device1
            MacNhom_ValueChanged(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/MacNhom"),
                         new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/MacNhom")
                         , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/MacNhom").Value));

            DuongKinh_ValueChanged(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/DuongKinh"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/DuongKinh")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/DuongKinh").Value));

            ApLucNuocL1_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApLucNuocL1"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApLucNuocL1")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApLucNuocL1").Value));

            VanTocSoiTitan_ValueChanged(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocSoiTitan"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocSoiTitan")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocSoiTitan").Value));

            TocDoCayKhuay_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/TocDoCayKhuay"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/TocDoCayKhuay")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/TocDoCayKhuay").Value));

            ApKhiArgon_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApKhiArgon"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApKhiArgon")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApKhiArgon").Value));

            VanTocXuongMam_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocXuongMam"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocXuongMam")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocXuongMam").Value));

            ChieuDaiPhoi_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ChieuDaiPhoi"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ChieuDaiPhoi")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ChieuDaiPhoi").Value));

            ThoiGianDongDac_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ThoiGianDongDac"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ThoiGianDongDac")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ThoiGianDongDac").Value));

            TanSoXuongMam_ValueChanged(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtXuongMam/f"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtXuongMam/f")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtXuongMam/f").Value));

            TanSoBomNuoc_ValueChanged(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtBomNuoc/f"),
                          new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtBomNuoc/f")
                          , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtBomNuoc/f").Value));
            //tag xuat excel
            ApLucNuocL1_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StartWriteExcel"),
                           new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StartWriteExcel")
                           , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StartWriteExcel").Value));

            ApLucNuocL1_ValueChanged1(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StopWriteExcel"),
                           new TagValueChangedEventArgs(EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StopWriteExcel")
                           , "", EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StopWriteExcel").Value));


            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauLoXaTruocKhi/Pv").ValueChanged += TSauLoXaTruocKhi_ValueChanged; ;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocGiaiNhietMam/Pv").ValueChanged += TNuocGiaiNhietMam_ValueChanged; ;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TKhongKhiTrongLo/Pv").ValueChanged += TKhongKhiTrongLo_ValueChanged1;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TNuocNhomTrongLo/Pv").ValueChanged += TNuocNhomTrongLo_ValueChanged1;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TSauTanOngTruocKhuon/Pv").ValueChanged += TSauTanOngTruocKhuon_ValueChanged1; ;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/TViTriThapNhatCuoiKhuon/Pv").ValueChanged += TViTriThapNhatCuoiKhuon_ValueChanged1;

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/MacNhom").ValueChanged += MacNhom_ValueChanged;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/DuongKinh").ValueChanged += DuongKinh_ValueChanged;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApLucNuocL1").ValueChanged += ApLucNuocL1_ValueChanged1;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocSoiTitan").ValueChanged += VanTocSoiTitan_ValueChanged;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/TocDoCayKhuay").ValueChanged += TocDoCayKhuay_ValueChanged1;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ApKhiArgon").ValueChanged += ApKhiArgon_ValueChanged1;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/VanTocXuongMam").ValueChanged += VanTocXuongMam_ValueChanged1; ;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ChieuDaiPhoi").ValueChanged += ChieuDaiPhoi_ValueChanged1;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/ThoiGianDongDac").ValueChanged += ThoiGianDongDac_ValueChanged1;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtXuongMam/f").ValueChanged += TanSoXuongMam_ValueChanged;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/InvtBomNuoc/f").ValueChanged += TanSoBomNuoc_ValueChanged;

            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StartWriteExcel").ValueChanged += StartWriteExcel_ValueChanged;
            EasyDriverConnectorProvider.GetEasyDriverConnector().GetTag("Local Station/Channel1/Device1/StopWriteExcel").ValueChanged += StopWriteExcel_ValueChanged;
        }

        private void StopWriteExcel_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue == "1")
                    {
                        //tat chup hinh
                        capScreenAction = false;
                        //xuat excel theo template

                        DataTable _res = DataProvider.Instance.ExecuteQuery("SELECT DateTime,MacNhom,DuongKinh,NhietDoNuocNhomTrongLo,NhietDoNhomTruocKhuon," +
                "NhietDoNhomCuoiKhuon,NhietDoNuocGiaiNhietMam,NhietDoNuocMatGieng,NhietDoKhongKhiTrongLo,ApLucNuocL1,VanTocSoiTitan,TocDoCayKhuay," +
                $"ApKhiArgon,VanTocXuongMam,ChieuDaiPhoi,ThoiGianDongDac,TanSoXuongMam,TanSoBomNuoc FROM sonthinhgiamsatloducnhom.data where DateTime >= '{timeStartExport}';");

                        if (_res.Rows.Count > 0)
                        {
                            excelHelper.ExportTemplate(VariableGlobal.TimeInterval.PathExcel, _res);
                        }
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void StartWriteExcel_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (e.NewValue == "1")
                    {
                        //lấy thời bắt đầu, để khi dừng sẽ get data từ đó xuất excel
                        timeStartExport = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        //bật cho phep chụp màn hình
                        capScreenAction = true;
                        startTimeCapture = DateTime.Now;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }



        #region Event tagValueChange
        private void TanSoBomNuoc_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (double.TryParse(e.NewValue, out double value))
                    {
                        parametterLocal.TanSoBomNuoc = value;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TanSoXuongMam_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (double.TryParse(e.NewValue, out double value))
                    {
                        parametterLocal.TanSoXuongMam = value;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }

        private void VanTocSoiTitan_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    if (double.TryParse(e.NewValue, out double value))
                    {
                        parametterLocal.VanTocSoiTitan = value;
                    }
                }));
            }
            catch (Exception)
            {

            }
        }
        private void ThoiGianDongDac_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.ThoiGianDongDac = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void ChieuDaiPhoi_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.ChieuDaiPhoi = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void VanTocXuongMam_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.VanTocXuongMam = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void ApKhiArgon_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.ApKhiArgon = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TocDoCayKhuay_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.TocDoCayKhuay = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void ApLucNuocL1_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.ApLucNuocL1 = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TViTriThapNhatCuoiKhuon_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.TViTriThapNhatCuoiKhuon = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TSauTanOngTruocKhuon_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.TSauTanOngTruocKhuon = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TNuocNhomTrongLo_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.TNuocNhomTrongLo = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TKhongKhiTrongLo_ValueChanged1(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.TKhongKhiTrongLo = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TNuocGiaiNhietMam_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.TNuocGiaiNhietMam = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void TSauLoXaTruocKhi_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.TSauLoXaTruocKhi = !string.IsNullOrEmpty(e.NewValue) ? Convert.ToDouble(e.NewValue) : 0;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void DuongKinh_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.DuongKinh = e.NewValue;
                }));
            }
            catch (Exception)
            {

            }
        }

        private void MacNhom_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            try
            {
                DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
                {
                    parametterLocal.MacNhom = e.NewValue;
                }));
            }
            catch (Exception)
            {

            }
        }
        #endregion


        private void _timerElapsed(object sender, ElapsedEventArgs e)
        {
            _timer.Enabled = false;

            //Dispatcher.BeginInvoke(new Action(() =>
            //{
            //    labTime.Content = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            //}));

            #region xét interval để log data
            stopTime = DateTime.Now;
            timeLog = stopTime - startTime;
            if (timeLog.TotalSeconds >= VariableGlobal.TimeInterval.ThoiGianLogData)
            {
                //Log data
                queryResult = DataProvider.Instance.ExecuteNonQuery($"insert into data (MacNhom,DuongKinh,NhietDoNuocNhomTrongLo,NhietDoSauTanOngTruocKhuon,NhietDoViTriThapNhatCuoiKhuon," +
                    $"NhietDoNuocGiaiNhietMam,NhietDoSauLoXaTruocKhi,NhietDoKhongKhiTrongLo,ApLucNuocL1,VanTocSoiTitan,TocDoCayKhuay,ApKhiArgon," +
                    $"VanTocXuongMam,ChieuDaiPhoi,ThoiGianDongDac,TanSoXuongMam,TanSoBomNuoc) " +
                    $"values ('{parametterLocal.MacNhom}','{parametterLocal.DuongKinh}',{parametterLocal.TNuocNhomTrongLo},{parametterLocal.TSauTanOngTruocKhuon}," +
                    $"{parametterLocal.TViTriThapNhatCuoiKhuon},{parametterLocal.TNuocGiaiNhietMam},{parametterLocal.TSauLoXaTruocKhi},{parametterLocal.TKhongKhiTrongLo}," +
                    $"{parametterLocal.ApLucNuocL1},{parametterLocal.VanTocSoiTitan},{parametterLocal.TocDoCayKhuay},{parametterLocal.ApKhiArgon},{parametterLocal.VanTocXuongMam}," +
                    $"{parametterLocal.ChieuDaiPhoi},{parametterLocal.ThoiGianDongDac},{parametterLocal.TanSoXuongMam},{parametterLocal.TanSoBomNuoc})");
                if (queryResult > 0)
                {
                    startTime = DateTime.Now;
                }
            }
            #endregion
            _timer.Enabled = true;
        }

        private void btnFrmParametter_Click(object sender, RoutedEventArgs e)
        {
            labTittle.Content = "GIÁM SÁT MÁY ĐÚC PHÔI";
            frmScreen1.Visibility = Visibility.Visible;
            frmReport.Visibility = Visibility.Hidden;
            frmSettings.Visibility = Visibility.Hidden;
            frmSettingsNguong.Visibility = Visibility.Hidden;
        }
        private void btnFrmReport_Click(object sender, RoutedEventArgs e)
        {
            labTittle.Content = "XUẤT BÁO CÁO";
            frmScreen1.Visibility = Visibility.Hidden;
            frmReport.Visibility = Visibility.Visible;
            frmSettings.Visibility = Visibility.Hidden;
            frmSettingsNguong.Visibility = Visibility.Hidden;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCaiDatNguong_Click(object sender, RoutedEventArgs e)
        {
            VariableGlobal.IsLogin = false;
            frmLogin nf = new frmLogin();
            nf.ShowDialog();

            if (VariableGlobal.IsLogin)
            {
                labTittle.Content = "CÀI ĐẶT NGƯỠNG XUẤT EXCEL";
                frmSettingsNguong.Visibility = Visibility.Visible;
                frmScreen1.Visibility = Visibility.Hidden;
                frmReport.Visibility = Visibility.Hidden;
                frmSettings.Visibility = Visibility.Hidden;
            }
        }

        private void imgMinimize_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnFrmSettings_Click(object sender, RoutedEventArgs e)
        {
            labTittle.Content = "CÀI ĐẶT NGƯỠNG NHIỆT ĐỘ";
            frmScreen1.Visibility = Visibility.Hidden;
            frmReport.Visibility = Visibility.Hidden;
            frmSettings.Visibility = Visibility.Visible;
            frmSettingsNguong.Visibility = Visibility.Hidden;
        }

        private Bitmap CS()
        {
            Bitmap bitmap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(0, 0, 0, 0, bitmap.Size);

            return bitmap;
        }
    }
}
