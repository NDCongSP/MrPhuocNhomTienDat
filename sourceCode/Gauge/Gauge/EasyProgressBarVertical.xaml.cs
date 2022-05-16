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
    /// Interaction logic for EasyProgressBarVertical.xaml
    /// </summary>
    public partial class EasyProgressBarVertical : UserControl
    {
        public EasyProgressBarVertical()
        {
            InitializeComponent();
            //GridLengthConverter gridConnverter = new GridLengthConverter();
            //row0.Height = (GridLength)gridConnverter.ConvertFrom("10*");
            //row1.Height = (GridLength)gridConnverter.ConvertFrom("90*");
        }
    }
}
