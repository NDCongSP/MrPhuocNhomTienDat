using EasyScada.Core;
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

namespace Gauge
{
    /// <summary>
    /// Interaction logic for EasyImageStatus.xaml
    /// </summary>
    public partial class EasyImageStatus : UserControl
    {
        public bool IsStarted { get; set; } = false;
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagName { get; set; }
        public BitmapImage SourceOn { get; set; }
        public BitmapImage SourceOff { get; set; }

        /// <summary>
        /// biến báo mức tích cực, dùng để so sánh bật tắt ảnh theo mức này.
        /// mặc định tích cực mức 1.
        /// </summary>
        public string activedLevel { get; set; } = "1";//biến báo mức tích cực, dùng để so sánh bật tắt ảnh theo mức này



        private IEasyDriverConnector Connector;
        private ITag tagStatus;

        //tạo DefaulrSource để hiển thị ảnh khi design runtime
        public BitmapImage DefaultSource
        {
            get { return (BitmapImage)GetValue(DefaultSourceProperty); }
            set { SetValue(DefaultSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultSourceProperty =
            DependencyProperty.Register("DefaultSource", typeof(BitmapImage), typeof(EasyImageStatus), new PropertyMetadata(null));


        public EasyImageStatus()
        {
            InitializeComponent();
        }

        public void Start()
        {
            if (!IsStarted)
            {
                IsStarted = true;
                Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();

                if (Connector.IsStarted)
                {
                    Connector_Started(Connector, EventArgs.Empty);
                }
                else
                {
                    Connector.Started += Connector_Started;
                }
            }
        }

        private ITag GetTag()
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{TagName}");
        }

        private void Connector_Started(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tagStatus = GetTag();
                if (tagStatus != null)
                {
                    TagStatus_ValueChanged(tagStatus, new TagValueChangedEventArgs(tagStatus, "", tagStatus.Value));
                    tagStatus.ValueChanged += TagStatus_ValueChanged;
                }
            }));
        }

        private void TagStatus_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (e?.NewValue == activedLevel)
                {
                    imgControl.Source = SourceOn;
                }
                else
                {
                    imgControl.Source = SourceOff;
                }
            }));
        }
    }
}
