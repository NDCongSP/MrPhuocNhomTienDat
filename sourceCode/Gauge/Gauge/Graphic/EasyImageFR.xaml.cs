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
    /// Interaction logic for EasyImaageFR.xaml
    /// </summary>
    public partial class EasyImageFR : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagForward { get; set; }
        public string TagReverse { get; set; }
        public string TagErorr { get; set; }
        public BitmapImage SourceOn { get; set; }
        public BitmapImage SourceOff { get; set; }
        public BitmapImage SourceError { get; set; }

        private IEasyDriverConnector Connector { get; set; }
        private ITag tagForward { get; set; }
        private ITag tagReverse { get; set; }
        private ITag tagEror { get; set; }
        private string tagForwardValue = "0", tagReverseValue = "0", tagErrorValue = "0";
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat


        public BitmapImage DefaultSource
        {
            get { return (BitmapImage)GetValue(DefaultSourceProperty); }
            set { SetValue(DefaultSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DefaultSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefaultSourceProperty =
            DependencyProperty.Register("DefaultSource", typeof(BitmapImage), typeof(EasyImageFR), new PropertyMetadata(null));
        public EasyImageFR()
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

                if (TagErorr != null)
                {
                    tagEror = GetTag(TagErorr);
                    if (tagEror != null)
                    {
                        TagEror_ValueChanged(tagEror, new TagValueChangedEventArgs(tagEror, "", tagEror.Value));
                        tagEror.ValueChanged += TagEror_ValueChanged;
                    }
                }
            }));
        }

        private void TagEror_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagErrorValue = e.NewValue;

                if (tagErrorValue == "1")
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        imgControl.Source = SourceError;
                    }));
                }
                else
                {
                    if (tagForwardValue == "1" || tagReverseValue == "1")
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            imgControl.Source = SourceOn;
                        }));

                    }
                    else if (tagForwardValue == "0" && tagReverseValue == "0")
                    {
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            imgControl.Source = SourceOff;
                        }));

                    }
                }
            }));
        }

        private void TagReverse_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagReverseValue = e.NewValue;

                if (TagErorr == null)//trường hợp ko có tag alarm
                {
                    if (tagReverseValue == "1")
                    {
                        imgControl.Source = SourceOn;
                    }
                    else
                    {
                        if (tagForwardValue == "0")
                        {
                            imgControl.Source = SourceOff;
                        }
                    }
                }
                else//trường hợp có tag alarm
                {
                    if (tagErrorValue == "0")
                    {
                        if (tagReverseValue == "1")
                        {
                            imgControl.Source = SourceOn;
                        }
                        else
                        {
                            if (tagForwardValue == "0")
                            {
                                imgControl.Source = SourceOff;
                            }
                        }
                    }
                }
            }));
        }

        private void TagForward_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                tagForwardValue = e.NewValue;

                if (TagErorr == null)//trường hợp ko có tag alarm
                {
                    if (tagForwardValue == "1")
                    {
                        imgControl.Source = SourceOn;
                    }
                    else
                    {
                        if (tagReverseValue == "0")
                        {
                            imgControl.Source = SourceOff;
                        }
                    }
                }
                else//trường hợp có tag alarm
                {
                    if (tagErrorValue == "0")
                    {
                        if (tagForwardValue == "1")
                        {
                            imgControl.Source = SourceOn;
                        }
                        else
                        {
                            if (tagReverseValue == "0")
                            {
                                imgControl.Source = SourceOff;
                            }
                        }
                    }
                }
            }));
        }
    }
}
