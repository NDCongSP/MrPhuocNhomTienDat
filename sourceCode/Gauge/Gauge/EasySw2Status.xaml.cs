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
    /// Interaction logic for EasySw2Status.xaml
    /// </summary>
    public partial class EasySw2Status : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }

        public string TagWriteName { get; set; }
        public string TagReadName { get; set; }

        private IEasyDriverConnector Connector { get; set; }
        private ITag tagWrite { get; set; }
        private ITag tagRead { get; set; }

        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        //public event EventHandler SwitchClick;
        #region Tao su kien de khi ghi thanh cong thi tra ra 1 event de form suwr dung control nay biet
        private string valueChange;
        public string ValueChange
        {
            get => valueChange;
            set
            {
                valueChange = value;
                OnNameChanged(value);
            }
        }


        private event EventHandler<ValueChangedEventArgs> _ValueChanged;
        public event EventHandler<ValueChangedEventArgs> ValueChanged
        {
            add
            {
                _ValueChanged += value;
            }
            remove
            {
                _ValueChanged -= value;
            }
        }

        void OnNameChanged(string valueChange)
        {
            if (_ValueChanged != null)
            {
                _ValueChanged?.Invoke(this, new ValueChangedEventArgs(valueChange));
            }
        }
        #endregion

        public string TitleLabel
        {
            get { return (string)GetValue(BtnContentProperty); }
            set { SetValue(BtnContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BtnContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BtnContentProperty =
            DependencyProperty.Register("TitleLabel", typeof(string), typeof(EasySw2Status), new PropertyMetadata("SWITCH"));

        public string TitleFontSize
        {
            get { return (string)GetValue(TitleFontSizeProperty); }
            set { SetValue(TitleFontSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BtnContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleFontSizeProperty =
            DependencyProperty.Register("TitleFontSize", typeof(string), typeof(EasySw2Status), new PropertyMetadata("12"));

        public EasySw2Status()
        {
            InitializeComponent();

            //TitleLabel = "SWITCH";
            //TitleFontSize = "12";
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
                tagRead = GetTag(TagReadName);
                if (tagRead != null)
                {
                    TagRead_ValueChanged(tagRead, new TagValueChangedEventArgs(tagRead, "", tagRead.Value));
                    tagRead.ValueChanged += TagRead_ValueChanged;
                }
                tagWrite = GetTag(TagWriteName);
            }));
        }

        private ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
        }

        private void TagRead_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (e?.NewValue == "1")
                {
                    imgControl.Source = (BitmapImage)this.FindResource("on");
                }
                else
                {
                    imgControl.Source = (BitmapImage)this.FindResource("off");
                }
            }));
        }

        private void imgControl_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            #region ghi giá trị xuống tag
            if (tagWrite != null)
            {
                if (tagWrite.Value == "0")
                {
                    //tagWrite.Write("1");
                    WriteResponse res = tagWrite.Write("1");
                    if (res.IsSuccess)
                    {
                        Console.WriteLine("ghi thanh cong gia tri 1");
                        ValueChange = "1";
                    }
                }
                else
                {
                    //tagWrite.Write("0");
                    WriteResponse res = tagWrite.Write("0");
                    if (res.IsSuccess)
                    {
                        Console.WriteLine("ghi thanh cong gia tri 0");
                        ValueChange = "0";
                    }
                }
            }
            #endregion
            //trả ra event để form sử dụng control biết
            //SwitchClick?.Invoke(this, e);
        }
    }
}
