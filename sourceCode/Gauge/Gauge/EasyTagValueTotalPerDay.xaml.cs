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
    /// Interaction logic for EasyTagValueTotalPerDay.xaml
    /// </summary>
    public partial class EasyTagValueTotalPerDay : UserControl
    {
        #region Public members
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagName { get; set; } = null;

        private IEasyDriverConnector Connector { get; set; }
        private ITag tagName { get; set; }
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        public double TagValueTotal
        {
            get { return (double)GetValue(TagValueTotalProperty); }
            set { SetValue(TagValueTotalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MachineRunTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagValueTotalProperty =
            DependencyProperty.Register("TagValueTotal", typeof(double), typeof(EasyTagValueTotalPerDay), new PropertyMetadata(null));


        public Brush FontColorLab
        {
            get { return (Brush)GetValue(FontColorLabProperty); }
            set { SetValue(FontColorLabProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontColorLab.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontColorLabProperty =
            DependencyProperty.Register("FontColorLab", typeof(Brush), typeof(EasyTagValueTotalPerDay), new PropertyMetadata(null));

        public HorizontalAlignment HorizontalAlignmentLab
        {
            get { return (HorizontalAlignment)GetValue(HorizontalAlignmentLabProperty); }
            set { SetValue(HorizontalAlignmentLabProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HorizontalAlignmentLab.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalAlignmentLabProperty =
            DependencyProperty.Register("HorizontalAlignmentLab", typeof(HorizontalAlignment), typeof(EasyTagValueTotalPerDay), new PropertyMetadata(null));
        #endregion

        #region private members
        private double tagValueTotalOld = 0, tagValue = 0;
        #endregion

        public EasyTagValueTotalPerDay()
        {
            InitializeComponent();

            this.DataContext = this;

            tagValueTotalOld = TagValueTotal = tagValue = 0;

            FontColorLab = Brushes.Black;

            HorizontalAlignmentLab = HorizontalAlignment.Center;

            this.labRunTime.PreviewMouseDown += LabRunTime_PreviewMouseDown;//đăng ký sự kiện click chuột vào label để reset lại bộ đếm thời gian.
        }

        private void LabRunTime_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            tagValueTotalOld = TagValueTotal = tagValue = 0;
        }

        private ITag GetTag(string tagName)
        {
            return Connector.GetTag($"{StationName}/{ChannelName}/{DeviceName}/{tagName}");
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
            Dispatcher.Invoke((Action)(() =>
            {
                if (!string.IsNullOrEmpty(TagName))
                {
                    tagName = GetTag(TagName);
                    if (tagName != null)
                    {
                        TagName_ValueChanged(tagName, new TagValueChangedEventArgs(tagName, "", tagName.Value));
                        tagName.ValueChanged += TagName_ValueChanged;
                    }
                }
            }));
        }

        private void TagName_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (double.TryParse(e.NewValue, out double value))
                {
                    tagValue = value;
                }

                if (tagValue != 0)
                {
                    TagValueTotal = tagValueTotalOld + tagValue;
                }
                else
                {
                    tagValueTotalOld = TagValueTotal;
                    tagValue = 0;
                }
            }));
        }
    }
}
