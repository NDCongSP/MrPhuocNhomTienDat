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
    /// Interaction logic for EasyCountRunTime.xaml
    /// </summary>
    public partial class EasyCountRunTime : UserControl
    {
        #region Public members
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string Tag1 { get; set; } = null;
        public string Tag2 { get; set; } = null;

        public string CountType { get; set; } = "TotalSeconds";//TotalMunites, TotalHours

        private IEasyDriverConnector Connector { get; set; }
        private ITag tag1 { get; set; }
        private ITag tag2 { get; set; }
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        public double MachineRunTime
        {
            get { return (double)GetValue(MachineRunTimeProperty); }
            set { SetValue(MachineRunTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MachineRunTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MachineRunTimeProperty =
            DependencyProperty.Register("MachineRunTime", typeof(double), typeof(EasyCountRunTime), new PropertyMetadata(null));

        public string TagStatus
        {
            get { return (string)GetValue(TagStatusProperty); }
            set { SetValue(TagStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TagStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagStatusProperty =
            DependencyProperty.Register("TagStatus", typeof(string), typeof(EasyCountRunTime), new PropertyMetadata("0"));



        public Brush FontColorLab
        {
            get { return (Brush)GetValue(FontColorLabProperty); }
            set { SetValue(FontColorLabProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontColorLab.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontColorLabProperty =
            DependencyProperty.Register("FontColorLab", typeof(Brush), typeof(EasyCountRunTime), new PropertyMetadata(null));



        public HorizontalAlignment HorizontalAlignmentLab
        {
            get { return (HorizontalAlignment)GetValue(HorizontalAlignmentLabProperty); }
            set { SetValue(HorizontalAlignmentLabProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HorizontalAlignmentLab.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalAlignmentLabProperty =
            DependencyProperty.Register("HorizontalAlignmentLab", typeof(HorizontalAlignment), typeof(EasyCountRunTime), new PropertyMetadata(null));
        #endregion

        #region private members
        private DateTime startTime, stopTime;
        private TimeSpan runTime;
        private bool flag = false;
        private Task taskCountTime;
        private string tag1Value = "0", tag2Value = "0";
        #endregion

        #region Contructor
        public EasyCountRunTime()
        {
            InitializeComponent();
            this.DataContext = this;

            startTime = stopTime = DateTime.Now;
            FontColorLab = Brushes.Black;
            HorizontalAlignmentLab = HorizontalAlignment.Center;
        }
        #endregion

        #region Public method
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
                if (!string.IsNullOrEmpty(Tag1))
                {
                    tag1 = GetTag(Tag1);
                    if (tag1 != null)
                    {
                        Tag1_ValueChanged(tag1, new TagValueChangedEventArgs(tag1, "", tag1.Value));
                        tag1.ValueChanged += Tag1_ValueChanged;
                    }
                }

                if (!string.IsNullOrEmpty(Tag2))
                {
                    tag2 = GetTag(Tag2);
                    if (tag2 != null)
                    {
                        Tag2_ValueChanged(tag2, new TagValueChangedEventArgs(tag2, "", tag2.Value));
                        tag2.ValueChanged += Tag2_ValueChanged;
                    }
                }
            }));
        }

        private void Tag2_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tag2Value = e.NewValue;

                if ((tag2Value == "1" && flag == false && tag1Value == "0") || (tag2Value == "1" && TagStatus == "0" && tag1Value == "1"))
                {
                    TagStatus = "1";
                    flag = true;

                    startTime = DateTime.Now;

                    //_timer.Enabled = true;
                    taskCountTime = new Task(() =>
                    {
                        while (flag)
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                stopTime = DateTime.Now;
                                runTime = stopTime - startTime;
                                if (CountType == "TotalSeconds")
                                {
                                    MachineRunTime = Math.Round(runTime.TotalSeconds, 0);
                                }
                                else if (CountType == "TotalMinutes")
                                {
                                    MachineRunTime = Math.Round(runTime.TotalMinutes, 0);
                                }
                                else
                                    MachineRunTime = Math.Round(runTime.TotalHours, 0);
                                //labRunTime.Content = MachineRunTime.ToString();                    
                            }));
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("DANG TINH THOI GIAN");
                        }
                        Console.WriteLine("DUNG TINH THOI GIAN");
                    });

                    taskCountTime.Start();
                }
                else if (tag2Value == "0" && flag == true && tag1Value == "0")
                {
                    flag = false;
                    TagStatus = "0";
                }
            }));
        }

        private void Tag1_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tag1Value = e.NewValue;

                if ((tag1Value == "1" && flag == false && tag2Value == "0") || (tag1Value == "1" && TagStatus == "0" && tag2Value == "1"))
                {
                    TagStatus = "1";
                    flag = true;

                    startTime = DateTime.Now;

                    //_timer.Enabled = true;
                    taskCountTime = new Task(() =>
                    {
                        while (flag)
                        {
                            Dispatcher.BeginInvoke(new Action(() =>
                            {
                                stopTime = DateTime.Now;
                                runTime = stopTime - startTime;
                                if (CountType == "TotalSeconds")
                                {
                                    MachineRunTime = Math.Round(runTime.TotalSeconds, 0);
                                }
                                else if (CountType == "TotalMinutes")
                                {
                                    MachineRunTime = Math.Round(runTime.TotalMinutes, 0);
                                }
                                else
                                    MachineRunTime = Math.Round(runTime.TotalHours, 0);
                                //labRunTime.Content = MachineRunTime.ToString();                    
                            }));
                            System.Threading.Thread.Sleep(1000);
                            Console.WriteLine("DANG TINH THOI GIAN");
                        }
                        Console.WriteLine("DUNG TINH THOI GIAN");
                    });

                    taskCountTime.Start();
                }
                else if (tag1Value == "0" && flag == true && tag2Value == "0")
                {
                    TagStatus = "0";
                    flag = false;
                }
            }));
        }
        #endregion
    }
}
