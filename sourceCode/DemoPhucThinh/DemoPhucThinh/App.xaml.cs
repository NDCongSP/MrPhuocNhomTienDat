using EasyScada.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace DemoPhucThinh
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //khoi tao 1 connector duy nhat trong du an, dung chung cho tat ca
        //public IEasyDriverConnector Connector { get; set; }
        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    Connector = EasyDriverConnectorProvider.GetEasyDriverConnector();
        //    Connector.Start();
        //    base.OnStartup(e);
        //}
    }
}
