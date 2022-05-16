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
    /// Interaction logic for EasyLabelStatus.xaml
    /// </summary>
    public partial class EasyLabelStatus : UserControl
    {
        public string StationName { get; set; }
        public string ChannelName { get; set; }
        public string DeviceName { get; set; }
        public string TagName { get; set; }
        private IEasyDriverConnector Connector { get; set; }
        private ITag tagName { get; set; } 
        public bool IsStarted { get; private set; } = false;//chi cho khoi dong 1 lan duy nhat

        public string LabContent
        {
            get { return (string)GetValue(LabContentProperty); }
            set { SetValue(LabContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LabContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabContentProperty =
            DependencyProperty.Register("LabContent", typeof(string), typeof(EasyLabelStatus), new PropertyMetadata(null));

        public string TagStatus
        {
            get { return (string)GetValue(TagStatusProperty); }
            set { SetValue(TagStatusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TagStatus.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagStatusProperty =
            DependencyProperty.Register("TagStatus", typeof(string), typeof(EasyLabelStatus), new PropertyMetadata("0"));


        public EasyLabelStatus()
        {
            InitializeComponent();
            this.DataContext = this;
            TagStatus = "0";
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
                tagName = GetTag(TagName);
                if (tagName != null)
                {
                    TagName_ValueChanged(tagName, new TagValueChangedEventArgs(tagName, "", tagName.Value));
                    tagName.ValueChanged += TagName_ValueChanged;
                }
            }));
        }

        private void TagName_ValueChanged(object sender, TagValueChangedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                TagStatus = e.NewValue;
                //MessageBox.Show(e.NewValue);
            }));
        }
    }
}
