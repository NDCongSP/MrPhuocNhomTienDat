using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace DemoPhucThinh
{
    /// <summary>
    /// Interaction logic for ucParametter.xaml
    /// </summary>
    public partial class ucParametter : UserControl
    {
        public bool IsStarted = false;
        //public IEasyDriverConnector Connector { get; set; }


        public ucParametter()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
                Loaded += OnLoaded;
            
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            //Start();
        }

        public void Start()
        {
            if (!IsStarted)
            {
                IsStarted = true;

                txtMacNhom.TagPath = "Local Station/Channel1/Device1/MacNhom";
                txtDuongKinh.TagPath = "Local Station/Channel1/Device1/DuongKinh";
                ////((App)App.Current).Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();

                //if (((App)App.Current).Connector.IsStarted)
                //{
                //    Connector_Started(((App)App.Current).Connector, EventArgs.Empty);
                //}
                //else
                //{
                //    ((App)App.Current).Connector.Started += Connector_Started;
                //}
            }
        }

        private void Connector_Started(object sender, EventArgs e)
        {
            Dispatcher.Invoke((Action)(() =>
            {
                
            }));
        }
    }
}
