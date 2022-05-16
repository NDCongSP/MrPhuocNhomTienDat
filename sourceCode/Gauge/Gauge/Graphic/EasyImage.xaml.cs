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
    /// Interaction logic for EasyImage.xaml
    /// </summary>
    public partial class EasyImage : UserControl
    {
        #region Public members
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagOnOff { get; set; }
        public string TagError { get; set; }
        public BitmapImage SourceOn { get; set; }
        public BitmapImage SourceOff { get; set; }
        public BitmapImage SourceError { get; set; }

        public BitmapImage DefaultSource
        {
            get { return (BitmapImage)GetValue(DefaultSourceProperty); }
            set { SetValue(DefaultSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultSourceProperty =
            DependencyProperty.Register("DefaultSource", typeof(BitmapImage), typeof(EasyImage), new PropertyMetadata(null));

        #endregion

        #region Private members
        private IEasyDriverConnector Connector { get; set; }
        private ITag tagOnOff { get; set; }
        private ITag tagAlarm { get; set; }
        #endregion

        #region Contructor
        public EasyImage()
        {
            InitializeComponent();
        }
        #endregion

        #region Public methods
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
                tagOnOff = GetTag(TagOnOff);
                if (tagOnOff != null)
                {
                    TagOnOff_ValueChanged(tagOnOff, new TagValueChangedEventArgs(tagOnOff, "", tagOnOff.Value));
                    tagOnOff.ValueChanged += TagOnOff_ValueChanged;
                }

                tagAlarm = GetTag(TagError);
                if (tagAlarm != null)
                {
                    TagAlarm_ValueChanged(tagAlarm, new TagValueChangedEventArgs(tagAlarm, "", tagAlarm.Value));
                    tagAlarm.ValueChanged += TagAlarm_ValueChanged;
                }
            }));
        }
        #endregion

        #region Event
        private void TagAlarm_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            //DispatcherService.Instance.AddToDispatcherQueue(new Action(() =>
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (e?.NewValue == "1")
                {
                    imgControl.Source = SourceError;
                }
                else
                {
                    if (tagOnOff?.Value == "1")
                    {
                        imgControl.Source = SourceOn;
                    }
                    else
                    {
                        imgControl.Source = SourceOff;
                    }
                }
            }));
        }

        private void TagOnOff_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                if (tagAlarm?.Value == "0")
                {
                    if (e?.NewValue == "1")
                    {
                        imgControl.Source = SourceOn;
                    }
                    else
                    {
                        imgControl.Source = SourceOff;
                    }
                }
            }));
        }
        #endregion
    }
}
