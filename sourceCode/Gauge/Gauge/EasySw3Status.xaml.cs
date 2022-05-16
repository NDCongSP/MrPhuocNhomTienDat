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
using EasyScada.Core;

namespace Gauge
{
    /// <summary>
    /// Interaction logic for EasySw3Status.xaml
    /// </summary>
    public partial class EasySw3Status : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagLeft { get; set; }
        public string TagRight { get; set; }

        public string TagLeftStatus { get; set; }
        public string TagRightStatus { get; set; }

        private IEasyDriverConnector Connector { get; set; }
        private ITag tagLeft { get; set; }
        private ITag tagRight { get; set; }
        private ITag tagLeftStatus { get; set; }
        private ITag tagRightStatus { get; set; }
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat




        //nội dung hiển thị bên trái
        public string LeftContent
        {
            get { return (string)GetValue(LeftContentProperty); }
            set { SetValue(LeftContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LeftContenr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LeftContentProperty =
            DependencyProperty.Register("LeftContent", typeof(string), typeof(EasySw3Status), new PropertyMetadata(null));



        public string RightContent
        {
            get { return (string)GetValue(RightContentProperty); }
            set { SetValue(RightContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RightContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RightContentProperty =
            DependencyProperty.Register("RightContent", typeof(string), typeof(EasySw3Status), new PropertyMetadata(null));


        public EasySw3Status()
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

        private void Connector_Started(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke((Action)(() =>
            {
                tagLeft = GetTag(TagLeft);
                tagRight = GetTag(TagRight);

                tagLeftStatus = GetTag(TagLeftStatus);
                if (tagLeftStatus != null)
                {
                    TagLeftStatus_ValueChanged(tagLeftStatus, new TagValueChangedEventArgs(tagLeftStatus, "", tagLeftStatus.Value));
                    tagLeftStatus.ValueChanged += TagLeftStatus_ValueChanged;
                }

                tagRightStatus = GetTag(TagRightStatus);
                if (tagRightStatus != null)
                {
                    TagRightStatus_ValueChanged(tagRightStatus, new TagValueChangedEventArgs(tagRightStatus, "", tagRightStatus.Value));
                    tagRightStatus.ValueChanged += TagRightStatus_ValueChanged;
                }
            }));
        }

        private ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        private void TagRightStatus_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (e?.NewValue=="1")
                {
                    imgControl.Source = (BitmapImage)this.FindResource("right");
                }
                else
                {
                    if (tagLeftStatus?.Value=="0")
                    {
                        imgControl.Source = (BitmapImage)this.FindResource("off");
                    }
                }
            }));
        }

        private void TagLeftStatus_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (e?.NewValue == "1")
                {
                    imgControl.Source = (BitmapImage)this.FindResource("left");
                }
                else
                {
                    if (tagRightStatus?.Value == "0")
                    {
                        imgControl.Source = (BitmapImage)this.FindResource("off");
                    }
                }
            }));
        }

        

        

        private void btnLeft_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagRight.Write("0");
                tagLeft.Write("1");
            }));
        }

        private void btnOff_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagLeft.Write("0");
                tagRight.Write("0");
            }));
        }

        private void btnRight_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagLeft.Write("0");
                tagRight.Write("1");
            }));
        }
    }
}
