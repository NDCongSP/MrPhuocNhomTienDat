using EasyScada.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for EasyButton.xaml
    /// </summary>
    public partial class EasyButton : UserControl
    {
        public EasyButton()
        {
            InitializeComponent();
        }
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagWriteName { get; set; }
        public string TagReadName { get; set; }

        public bool ButtonType { get; set; } = false;//chọn nút nhấn giữ hay nhấn nhả, nếu =false là nhấn nhả (ghi lên 1 sau 2s ghi về 0); =true nhấn giữ

        private IEasyDriverConnector Connector { get; set; }
        private ITag tagWrite { get; set; }
        private ITag tagRead { get; set; }

        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        public Brush ActiveColor { get; set; } = Brushes.Green;

        //public Brush ActiveColor
        //{
        //    get { return (Brush)GetValue(ActiveColorProperty); }
        //    set { SetValue(ActiveColorProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ActiveColorProperty =
        //    DependencyProperty.Register("ActiveColor", typeof(Brush), typeof(EasyButton), new PropertyMetadata(Brushes.Green));



        public string BtnContent
        {
            get { return (string)GetValue(BtnContentProperty); }
            set { SetValue(BtnContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BtnContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BtnContentProperty =
            DependencyProperty.Register("BtnContent", typeof(string), typeof(EasyButton), new PropertyMetadata(null));

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
                if (tagWrite != null)
                {
                    btnEasy.Click += (s, o) =>
                    {
                        switch (ButtonType)
                        {
                            case false://mode nhấn nhả
                                tagWrite.Write("1");
                                Thread.Sleep(2000);
                                tagWrite.Write("0");
                                break;
                            case true:
                                if (tagWrite.Value=="0")
                                {
                                    //tagWrite.Write("1");
                                    WriteResponse res = tagWrite.Write("1");
                                    if (res.IsSuccess)
                                    {
                                        //Console.WriteLine("ghi thanh cong gia tri 1");
                                        ValueChange = "1";
                                    }
                                }
                                else
                                {
                                    //tagWrite.Write("0");
                                    WriteResponse res = tagWrite.Write("0");
                                    if (res.IsSuccess)
                                    {
                                        //Console.WriteLine("ghi thanh cong gia tri 0");
                                        ValueChange = "0";
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        
                    };
                }
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
                    btnEasy.Background = ActiveColor;
                }
                else
                {
                    btnEasy.Background = new SolidColorBrush(Color.FromRgb(221, 221, 221));
                }
            }));
        }

        //private void btnEasy_Click(object sender, RoutedEventArgs e)
        //{
        //    Dispatcher.BeginInvoke(new Action(() =>
        //    {
        //        if (tagWrite != null)
        //        {
        //            tagWrite.Write("1");
        //            Thread.Sleep(2000);
        //            tagWrite.Write("0");
        //        }
        //    }));
        //}
    }

    //public class ValueEvent
    //{
    //    private string valueChange;
    //    public string ValueChange
    //    {
    //        get => valueChange;
    //        set
    //        {
    //            valueChange = value;
    //            OnNameChanged(value);
    //        }
    //    }


    //    private event EventHandler<ValueChangedEventArgs> _ValueChanged;
    //    public event EventHandler<ValueChangedEventArgs> ValueChanged
    //    {
    //        add
    //        {
    //            _ValueChanged += value;
    //        }
    //        remove
    //        {
    //            _ValueChanged -= value;
    //        }
    //    }

    //    void OnNameChanged(string valueChange)
    //    {
    //        if (_ValueChanged != null)
    //        {
    //            _ValueChanged?.Invoke(this, new ValueChangedEventArgs(valueChange));
    //        }
    //    }
    //}

    public class ValueChangedEventArgs : EventArgs
    {
        public string tagValue { get; set; }

        public ValueChangedEventArgs(string value)
        {
            tagValue = value;
        }


    }
}
