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
    /// Interaction logic for EasyImageStatusGif.xaml
    /// </summary>
    public partial class EasyImageStatusGif : UserControl
    {
        public bool IsStarted { get; set; } = false;
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagName { get; set; }

        private IEasyDriverConnector Connector;
        private ITag tagStatus;

        public BitmapImage GifSource
        {
            get { return (BitmapImage)GetValue(GifSourceProperty); }
            set { SetValue(GifSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GifSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GifSourceProperty =
            DependencyProperty.Register("GifSource", typeof(BitmapImage), typeof(EasyImageStatusGif), new PropertyMetadata(null));



        public EasyImageStatusGif()
        {
            InitializeComponent();
            
        }

        public void Start()
        {
            if (!IsStarted)
            {
                IsStarted = true;
                Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();

                //imgOn.Visibility = Visibility.Hidden;

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
                if (e?.NewValue == "1")
                {
                    imgOn.Visibility = Visibility.Visible;
                }
                else
                {
                    imgOn.Visibility = Visibility.Hidden;
                }
            }));
        }
    }
}
