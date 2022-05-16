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
    /// Interaction logic for EasyImageStatusGifFR.xaml
    /// </summary>
    public partial class EasyImageStatusGifFR : UserControl
    {
        #region Public members
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagForward { get; set; }
        public string TagReverse { get; set; }
        private IEasyDriverConnector Connector { get; set; }
        private ITag tagForward { get; set; }
        private ITag tagReverse { get; set; }
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        public BitmapImage GifSource
        {
            get { return (BitmapImage)GetValue(GifSourceProperty); }
            set { SetValue(GifSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for GifSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GifSourceProperty =
            DependencyProperty.Register("GifSource", typeof(BitmapImage), typeof(EasyImageStatusGifFR), new PropertyMetadata(null));
        #endregion

        private string tagForwardValue = "0", tagReverseValue = "0";

        public EasyImageStatusGifFR()
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
        private ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        private void Connector_Started(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tagForward = GetTag(TagForward);
                if (tagForward != null)
                {
                    TagForward_ValueChanged(tagForward, new TagValueChangedEventArgs(tagForward, "", tagForward.Value));
                    tagForward.ValueChanged += TagForward_ValueChanged;
                }

                tagReverse = GetTag(TagReverse);
                if (tagReverse != null)
                {
                    TagReverse_ValueChanged(tagReverse, new TagValueChangedEventArgs(tagReverse, "", tagReverse.Value));
                    tagReverse.ValueChanged += TagReverse_ValueChanged;
                }
            }));
        }

        private void TagReverse_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagReverseValue = e.NewValue;
                if (tagReverseValue == "1")
                {
                    imgOn.Visibility = Visibility.Visible;
                }
                else
                {
                    if (tagForwardValue == "0")
                    {
                        imgOn.Visibility = Visibility.Hidden;
                    }
                }
            }));
        }

        private void TagForward_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagForwardValue = e.NewValue;

                if (tagForwardValue == "1")
                {
                    imgOn.Visibility = Visibility.Visible;
                }
                else
                {
                    if (tagReverseValue == "0")
                    {
                        imgOn.Visibility = Visibility.Hidden;
                    }
                }
            }));
        }
    }
}
