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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gauge
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class TempGauge : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagName { get; set; }
        public string TitleGauge { get; set; }
        private IEasyDriverConnector Connector { get; set; }
        private ITag TagValue { get; set; }
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        public double MaxValue { get; set; } = 100;
        public double MinValue { get; set; } = 0;

        private double mathPoint = 0, positionPoint = 0;

        //Storyboard dailBoard = new Storyboard();
        //DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
        //EasingDoubleKeyFrame frameVariable = new EasingDoubleKeyFrame();

        public TempGauge()
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

                labTitle.Content = TitleGauge;//gắn title cho gauge
                //tính toán chia khoảng hiển thị trên label
                double khoanChia = MaxValue / 10;
                labLevel0.Content = "0";
                labLevel1.Content = khoanChia.ToString();
                labLevel2.Content = (khoanChia * 2).ToString();
                labLevel3.Content = (khoanChia * 3).ToString();
                labLevel4.Content = (khoanChia * 4).ToString();
                labLevel5.Content = (khoanChia * 5).ToString();
                labLevel6.Content = (khoanChia * 6).ToString();
                labLevel7.Content = (khoanChia * 7).ToString();
                labLevel8.Content = (khoanChia * 8).ToString();
                labLevel9.Content = (khoanChia * 9).ToString();
                labLevel10.Content = (khoanChia * 10).ToString();
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
                TagValue = GetTag();
                if (TagValue != null)
                {
                    TagValue_ValueChanged(TagValue, new TagValueChangedEventArgs(TagValue, "", TagValue.Value));
                    TagValue.ValueChanged += TagValue_ValueChanged;
                }
            }));
        }

        private void TagValue_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                labValue.Content = e.NewValue;//hiển thị label giá trị

                #region tính toán để hiển thị kim đồng hồ đúng với giá trị

                //     < !--Cách chia độ trên gauge
                //StartPoint = -130; EndPoint = 130 ==> 260 ==> 260 / MaxValue = giaTriDoTuongUngVoi1DonViValue ==> positionPoint = -130 + (giaTriDoTuongUngVoi1DonViValue * value)
                mathPoint = (260 / MaxValue) * Convert.ToDouble(e.NewValue);//tinh ra xem với giá trị hiện tại tương ứng với bao nhiêu độ
                positionPoint = -130 + mathPoint;//tính ra vị trí của mũi tên tương ứng
                if (positionPoint > 130)
                {
                    positionPoint = 130;
                }

                //System.Windows.Media.Animation.Storyboard dailBoard1 = new System.Windows.Media.Animation.Storyboard();
                Storyboard dailBoard = new Storyboard();
                DoubleAnimationUsingKeyFrames da = new DoubleAnimationUsingKeyFrames();
                EasingDoubleKeyFrame frameVariable = new EasingDoubleKeyFrame();

                Storyboard.SetTarget(da, arrowPointer);
                Storyboard.SetTargetProperty(da, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)"));


                frameVariable.KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromSeconds(1));
                frameVariable.Value = positionPoint;

                da.KeyFrames.Add(frameVariable);
                dailBoard.Children.Add(da);

                dailBoard.Begin();
                #endregion
            }));
        }
    }
}
