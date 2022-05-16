using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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
using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Wpf;

namespace Gauge
{
    /// <summary>
    /// Interaction logic for easyRealTimeTrend.xaml
    /// </summary>
    public partial class easyRealTimeTrend : UserControl, INotifyPropertyChanged
    {
        public easyRealTimeTrend()
        {
            InitializeComponent();
            DataContext = this;
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

                var mapper = Mappers.Xy<MeasureModel>()
                   .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                   .Y(model => model.Value);           //use the value property as Y

                //lets save the mapper globally.
                Charting.For<MeasureModel>(mapper);

                //lets set how to display the X Labels
                //DateTimeFormatter = value => new DateTime((long)value).ToString("dd/MM/yyyy HH:mm:ss");
                DateTimeFormatter = value => new DateTime((long)value).ToString("HH:mm");
                ValueFormat = value => Math.Round(value, 2).ToString();

                //AxisStep forces the distance between each separator in the X axis
                //AxisStep = TimeSpan.FromSeconds(StepLabelX).Ticks;//cài đặt số điểm hiển thị trên label trục x
                AxisStep = TimeSpan.FromMinutes(StepLabelX).Ticks;//cài đặt số điểm hiển thị trên label trục x

                //AxisUnit forces lets the axis know that we are plotting seconds
                //this is not always necessary, but it can prevent wrong labeling
                //AxisUnit = TimeSpan.FromSeconds(1).Ticks;//cài đặt bao nhiêu point thì random 1 lần
                AxisUnit = TimeSpan.FromMinutes(10).Ticks;//cài đặt bao nhiêu point thì random 1 lần

                SetAxisLimits(DateTime.Now);//sét min và max cảu trục x

                #region khởi tạo Series
                if (!string.IsNullOrEmpty(TagName1))
                {
                    series1 = new LineSeries();
                    series1.LineSmoothness = 0;
                    series1.StrokeThickness = 4;
                    series1.Stroke = new SolidColorBrush(Color.FromRgb(41, 191, 18));//green
                    series1.Fill = Brushes.Transparent;
                    series1.PointGeometry = DefaultGeometries.None;
                    ChartValuesSeries1 = new ChartValues<MeasureModel>();
                    series1.Values = ChartValuesSeries1;
                    series1.Title = Title1;//Legends
                    series1.FontSize = 10;
                    series1.DataLabels = false;
                    series1.Foreground = Brushes.White;
                    realTimeChart.Series.Add(series1);
                }

                if (!string.IsNullOrEmpty(TagName2))
                {
                    series2 = new LineSeries();
                    series2.LineSmoothness = 0;
                    series2.StrokeThickness = 4;
                    series2.Stroke = new SolidColorBrush(Color.FromRgb(7, 42, 200));//blue
                    series2.Fill = Brushes.Transparent;
                    series2.PointGeometry = DefaultGeometries.None;
                    ChartValuesSeries2 = new ChartValues<MeasureModel>();
                    series2.Values = ChartValuesSeries2;
                    series2.Title = Title2;//Legends
                    series2.FontSize = 10;
                    series2.DataLabels = false;
                    series2.Foreground = Brushes.White;
                    realTimeChart.Series.Add(series2);
                }

                if (!string.IsNullOrEmpty(TagName3))
                {
                    series3 = new LineSeries();
                    series3.LineSmoothness = 0;
                    series3.StrokeThickness = 4;
                    series3.Stroke = new SolidColorBrush(Color.FromRgb(239, 246, 238));//white. get form coolors.co
                    series3.Fill = Brushes.Transparent;
                    series3.PointGeometry = DefaultGeometries.None;
                    ChartValuesSeries3 = new ChartValues<MeasureModel>();
                    series3.Values = ChartValuesSeries3;
                    series3.Title = Title3;//Legends
                    series3.FontSize = 10;
                    series3.DataLabels = false;
                    series3.Foreground = Brushes.White;
                    realTimeChart.Series.Add(series3);
                }
                #endregion

                IsReading = true;
                //btnChart.Background = new SolidColorBrush(Color.FromRgb(41, 191, 18));
                //Task.Factory.StartNew(Read);//chay chart

                aTimer = new System.Timers.Timer(Interval);
                // Hook up the Elapsed event for the timer. 
                aTimer.Elapsed += OnTimedEvent;
                aTimer.AutoReset = true;
                aTimer.Enabled = true;
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                var now = DateTime.Now;
                if (!string.IsNullOrEmpty(TagName1))
                {
                    ChartValuesSeries1.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = series1Value
                    });

                    //lets only use the last 150 values
                    if (ChartValuesSeries1.Count > PointNums)
                        ChartValuesSeries1.RemoveAt(0);
                }

                if (!string.IsNullOrEmpty(TagName2))
                {
                    ChartValuesSeries2.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = series2Value
                    });

                    if (ChartValuesSeries2.Count > PointNums)
                        ChartValuesSeries2.RemoveAt(0);
                }

                if (!string.IsNullOrEmpty(TagName3))
                {
                    ChartValuesSeries3.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = series3Value
                    });

                    if (ChartValuesSeries3.Count > PointNums)
                        ChartValuesSeries3.RemoveAt(0);
                }

                SetAxisLimits(now);
            }));

            if (IsReading)
            {
                aTimer.Enabled = true;
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
                tagName1 = GetTag(TagName1);
                if (tagName1 != null)
                {
                    TagName1_ValueChanged(tagName1, new TagValueChangedEventArgs(tagName1, "", tagName1.Value));
                    tagName1.ValueChanged += TagName1_ValueChanged;
                }

                tagName2 = GetTag(TagName2);
                if (tagName2 != null)
                {
                    TagName2_ValueChanged(tagName2, new TagValueChangedEventArgs(tagName2, "", tagName2.Value));
                    tagName2.ValueChanged += TagName2_ValueChanged;
                }

                tagName3 = GetTag(TagName3);
                if (tagName3 != null)
                {
                    TagName3_ValueChanged(tagName3, new TagValueChangedEventArgs(tagName3, "", tagName3.Value));
                    tagName3.ValueChanged += TagName3_ValueChanged;
                }
            }));
        }

        private void TagName3_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (double.TryParse(e.NewValue, out double value))
                {
                    series3Value = Math.Round(value, 2);
                }
            }));
        }

        private void TagName2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (double.TryParse(e.NewValue, out double value))
                {
                    series2Value = Math.Round(value, 2);
                }
            }));
        }

        private void TagName1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (double.TryParse(e.NewValue, out double value))
                {
                    series1Value = Math.Round(value, 2);
                }
            }));
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Public properties
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagName1 { get; set; }
        public string TagName2 { get; set; }
        public string TagName3 { get; set; }
        public string Title1 { get; set; } = "Title 1";
        public string Title2 { get; set; } = "Title 2";
        public string Title3 { get; set; } = "Title 3";
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat
        public ChartValues<MeasureModel> ChartValuesSeries1 { get; set; }
        public ChartValues<MeasureModel> ChartValuesSeries2 { get; set; }
        public ChartValues<MeasureModel> ChartValuesSeries3 { get; set; }

        public Func<double, string> DateTimeFormatter { get; set; }
        public Func<double, string> ValueFormat { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }

        [Browsable(true), Category(DesignerCategory.EASYSCADA), DisplayName("Interval (ms)")]
        public int Interval { get; set; } = 100;

        [Browsable(true), Category(DesignerCategory.EASYSCADA), Description("The point is showing on the chart.")]
        public int PointNums { get; set; } = 200;//số điểm hiển thị trên chart

        [Browsable(true), Category(DesignerCategory.EASYSCADA), DisplayName("Step X")]
        public int StepLabelX { get; set; } = 5;//số điểm hiển thị trên chart

        [Browsable(true), Category(DesignerCategory.EASYSCADA)]
        public double AxisYMax
        {
            get { return _axisYMax; }
            set
            {
                _axisYMax = value;
                OnPropertyChanged("AxisYMax");
            }
        }
        [Browsable(true), Category(DesignerCategory.EASYSCADA)]
        public double AxisYMin
        {
            get { return _axisYMin; }
            set
            {
                _axisYMin = value;
                OnPropertyChanged("AxisYMin");
            }
        }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        public bool IsReading { get; set; } = true;

        #endregion

        #region Private properties
        private IEasyDriverConnector Connector { get; set; }
        private ITag tagName1 { get; set; }
        private ITag tagName2 { get; set; }
        private ITag tagName3 { get; set; }

        private static System.Timers.Timer aTimer;

        private double series1Value = 0, series2Value = 0, series3Value = 0;
        //bat tat series
        private bool enableSeries1 = false;


        //cau hinh chart
        private double _axisMax = 10;
        private double _axisMin = 0;
        private double _trend;
        private double _axisYMax = 10;
        private double _axisYMin = 0;

        private LineSeries series1, series2, series3;
        #endregion

        private void SetAxisLimits(DateTime now)
        {
            //AxisMax = now.Ticks + TimeSpan.FromSeconds(0).Ticks; // lets force the axis to be 1 second ahead
            //AxisMin = now.Ticks - TimeSpan.FromSeconds(60).Ticks; // and 8 seconds behind

            AxisMax = now.Ticks + TimeSpan.FromMinutes(0).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromMinutes(20).Ticks; // and 8 seconds behind
        }

        private void SetAxisLimits(DateTime min, DateTime max)
        {
            AxisMax = max.Ticks; // lets force the axis to be 1 second ahead
            AxisMin = min.Ticks; // and 8 seconds behind
        }

        //nút nhấn onOff chart
        //private void InjectStopOnClick(object sender, RoutedEventArgs e)
        //{
        //    IsReading = !IsReading;
        //    if (IsReading)
        //    {
        //        Task.Factory.StartNew(Read);
        //        btnChart.Background = new SolidColorBrush(Color.FromRgb(41, 191, 18));
        //    }
        //    else
        //    {
        //        btnChart.Background = new SolidColorBrush(Color.FromRgb(255, 153, 20));
        //    }
        //}

        private void Read()
        {
            while (IsReading)
            {
                Dispatcher.Invoke(() =>
                {
                    Thread.Sleep(Interval);
                    var now = DateTime.Now;

                    ChartValuesSeries1.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = series1Value
                    });

                    SetAxisLimits(now);

                    //lets only use the last 150 values
                    if (ChartValuesSeries1.Count > PointNums)
                        ChartValuesSeries1.RemoveAt(0);
                });
            }
        }
    }

    public class MeasureModel
    {
        public DateTime DateTime { get; set; }
        public double Value { get; set; }
    }
}
