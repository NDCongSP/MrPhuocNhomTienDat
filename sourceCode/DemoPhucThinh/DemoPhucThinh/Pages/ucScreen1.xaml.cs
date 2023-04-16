using System;
using System.Collections.Generic;
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
    /// Interaction logic for ucScreen1.xaml
    /// </summary>
    public partial class ucScreen1 : UserControl
    {
        public ucScreen1()
        {
            InitializeComponent();

            gauge1.TitleGauge = "VT xuống mâm";
            gauge1.StationName = "Local Station";
            gauge1.ChannelName = "Channel1";
            gauge1.DeviceName = "Device1";
            gauge1.TagName = "VanTocXuongMam";
            gauge1.MaxValue = 10;
            gauge1.Start();

            progBarChieuDaiPhoi.StationName = "Local Station";
            progBarChieuDaiPhoi.ChannelName = "Channel1";
            progBarChieuDaiPhoi.DeviceName = "Device1";
            progBarChieuDaiPhoi.TagName = "ChieuDaiPhoi";
            progBarChieuDaiPhoi.Start();

            realTimeChart.StationName = "Local Station";
            realTimeChart.ChannelName = "Channel1";
            realTimeChart.DeviceName = "Device1";
            realTimeChart.TagName1 = "VanTocXuongMam";
            realTimeChart.TagName2 = "ApLucNuocL1";
            realTimeChart.TagName3 = null;
            realTimeChart.Title1 = "VT xuống mâm";
            realTimeChart.Title2 = "Áp lực nước L1";
            realTimeChart.Title3 = null;
            realTimeChart.Start();
        }

        private void realTimeChart_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
