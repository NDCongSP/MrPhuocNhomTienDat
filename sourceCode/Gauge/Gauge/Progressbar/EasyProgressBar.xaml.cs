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
    /// Interaction logic for EasyProgressBar.xaml
    /// </summary>
    public partial class EasyProgressBar : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagName { get; set; }

        public bool ButtonType { get; set; } = false;//chọn nút nhấn giữ hay nhấn nhả, nếu =false là nhấn nhả (ghi lên 1 sau 2s ghi về 0); =true nhấn giữ

        private IEasyDriverConnector Connector { get; set; }
        private ITag tagName { get; set; }

        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        public Brush LabelColor { get; set; } = Brushes.Green;
        public Brush ProgBarlColor { get; set; } = Brushes.Blue;


        public HorizontalAlignment HorizontalBar
        {
            get { return (HorizontalAlignment)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("HorizontalBar", typeof(HorizontalAlignment), typeof(EasyProgressBar), new PropertyMetadata(null));



        public int MaxValue//gia trị lớn nhất cho progress bar
        {
            get { return (int)GetValue(WidthValueProperty); }
            set { SetValue(WidthValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WidthValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WidthValueProperty =
            DependencyProperty.Register("MaxValue", typeof(int), typeof(EasyProgressBar), new PropertyMetadata(null));

        public int HeightBar
        {
            get { return (int)GetValue(HeightBarProperty); }
            set { SetValue(HeightBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HeightBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeightBarProperty =
            DependencyProperty.Register("HeightBar", typeof(int), typeof(EasyProgressBar), new PropertyMetadata(null));

        public double ValueBar
        {
            get { return (double)GetValue(ValueBarProperty); }
            set { SetValue(ValueBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValueBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueBarProperty =
            DependencyProperty.Register("ValueBar", typeof(double), typeof(EasyProgressBar), new PropertyMetadata(null));

        public string TitleBar
        {
            get { return (string)GetValue(TitleBarProperty); }
            set { SetValue(TitleBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TitleBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleBarProperty =
            DependencyProperty.Register("TitleBar", typeof(string), typeof(EasyProgressBar), new PropertyMetadata(null));

        public int FontSizeBar
        {
            get { return (int)GetValue(FontSizeBarProperty); }
            set { SetValue(FontSizeBarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontSizeBar.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontSizeBarProperty =
            DependencyProperty.Register("FontSizeBar", typeof(int), typeof(EasyProgressBar), new PropertyMetadata(12));



        public Visibility VisibilityLabel
        {
            get { return (Visibility)GetValue(VisibilityLabelProperty); }
            set { SetValue(VisibilityLabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VisibilityLabel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VisibilityLabelProperty =
            DependencyProperty.Register("VisibilityLabel", typeof(Visibility), typeof(EasyProgressBar), new PropertyMetadata(null));






        public EasyProgressBar()
        {
            InitializeComponent();
            ValueBar = 0;
        }

        public void Start()
        {
            if (!IsStarted)
            {
                IsStarted = true;
                Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();

                labProg1.Foreground = LabelColor;
                labTitle.Foreground = LabelColor;
                prog1.Background = ProgBarlColor;

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
                tagName = GetTag(TagName);
                if (tagName != null)
                {
                    TagValue_ValueChanged(tagName, new TagValueChangedEventArgs(tagName, "", tagName.Value));
                    tagName.ValueChanged += TagValue_ValueChanged;
                }
            }));
        }

        private void TagValue_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (double.TryParse(e.NewValue, out double value))
                {
                    if (value < MaxValue)
                    {
                        ValueBar = value;
                    }
                    else
                    {
                        ValueBar = MaxValue;
                    }
                }
            }));
        }
    }
}
