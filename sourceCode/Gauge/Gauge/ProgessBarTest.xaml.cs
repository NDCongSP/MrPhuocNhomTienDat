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
    /// Interaction logic for ProgessBarTest.xaml
    /// </summary>
    public partial class ProgessBarTest : UserControl
    {
        public int maxValue = 200;//this is max value of progress
        public ProgessBarTest()
        {
            InitializeComponent();
            mthINIT();
        }

        private void mthINIT()
        {
            btnRun.Click += (s, o) =>
            {
                if (prog1.Width < maxValue)
                {
                    prog1.Width += 2;
                }
                else
                    prog1.Width = 0;

                if (prog2.Width < maxValue)
                {
                    prog2.Width += 2;
                }
                else
                    prog2.Width = 0;

                if (prog3.Height < maxValue)
                {
                    prog3.Height += 2;
                }
                else
                    prog3.Height = 0;
            };

        }
    }
}
