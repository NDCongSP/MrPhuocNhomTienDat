using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoPhucThinh
{
    /// <summary>
    /// Interaction logic for ucTrend.xaml
    /// </summary>
    public partial class ucScreenParametter : UserControl
    {
        private bool isLoaded = false;

        public ucScreenParametter()
        {
            InitializeComponent();

            //để xử lý vấn đề khi code mà nó báo lỗi do nó run các chức năng
            if (!DesignerProperties.GetIsInDesignMode(this))
                Loaded += OnLoaded;
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            if (!isLoaded)
            {
                isLoaded = true;

                gaugeNdNuocMatGieng.TitleGauge = "Nhiệt độ nước mặt giếng (oC)";
                gaugeNdNuocMatGieng.StationName = "Local Station";
                gaugeNdNuocMatGieng.ChannelName = "Channel1";
                gaugeNdNuocMatGieng.DeviceName = "TSauLoXaTruocKhi";
                gaugeNdNuocMatGieng.TagName = "Pv";
                gaugeNdNuocMatGieng.MaxValue = 100;
                gaugeNdNuocMatGieng.Start();

                gaugeNdNuocGiaiNhietMam.TitleGauge = "Nhiệt độ nước giải nhiệt mâm (oC)";
                gaugeNdNuocGiaiNhietMam.StationName = "Local Station";
                gaugeNdNuocGiaiNhietMam.ChannelName = "Channel1";
                gaugeNdNuocGiaiNhietMam.DeviceName = "TNuocGiaiNhietMam";
                gaugeNdNuocGiaiNhietMam.TagName = "Pv";
                gaugeNdNuocGiaiNhietMam.MaxValue = 100;
                gaugeNdNuocGiaiNhietMam.Start();

                gaugeNdKhongKhiTrongLo.TitleGauge = "Nhiệt độ không khí trong lò (oC)";
                gaugeNdKhongKhiTrongLo.StationName = "Local Station";
                gaugeNdKhongKhiTrongLo.ChannelName = "Channel1";
                gaugeNdKhongKhiTrongLo.DeviceName = "TKhongKhiTrongLo";
                gaugeNdKhongKhiTrongLo.TagName = "Pv";
                gaugeNdKhongKhiTrongLo.MaxValue = 1000;
                gaugeNdKhongKhiTrongLo.Start();

                gaugeNdNuocNhomTrongLo.TitleGauge = "Nhiệt độ nước nhôm trong lò (oC)";
                gaugeNdNuocNhomTrongLo.StationName = "Local Station";
                gaugeNdNuocNhomTrongLo.ChannelName = "Channel1";
                gaugeNdNuocNhomTrongLo.DeviceName = "TNuocNhomTrongLo";
                gaugeNdNuocNhomTrongLo.TagName = "Pv";
                gaugeNdNuocNhomTrongLo.MaxValue = 1000;
                gaugeNdNuocNhomTrongLo.Start();

                gaugeNdNhomTaiMiengLo.TitleGauge = "Nhiệt độ nhôm tại miệng lò (oC)";
                gaugeNdNhomTaiMiengLo.StationName = "Local Station";
                gaugeNdNhomTaiMiengLo.ChannelName = "Channel1";
                gaugeNdNhomTaiMiengLo.DeviceName = "TViTriThapNhatCuoiKhuon";
                gaugeNdNhomTaiMiengLo.TagName = "Pv";
                gaugeNdNhomTaiMiengLo.MaxValue = 1000;
                gaugeNdNhomTaiMiengLo.Start();

                gaugeNdNhomTruocKhuon.TitleGauge = "Nhiệt độ nhôm trước khuôn (oC)";
                gaugeNdNhomTruocKhuon.StationName = "Local Station";
                gaugeNdNhomTruocKhuon.ChannelName = "Channel1";
                gaugeNdNhomTruocKhuon.DeviceName = "TSauTanOngTruocKhuon";
                gaugeNdNhomTruocKhuon.TagName = "Pv";
                gaugeNdNhomTruocKhuon.MaxValue = 1000;
                gaugeNdNhomTruocKhuon.Start();

             
            }
        }
    }
}
